using System.Collections.Concurrent;
using System.Runtime.Serialization;
using GoldsparkIT.OCPP.Enums;
using GoldsparkIT.OCPP.Exceptions;
using GoldsparkIT.OCPP.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace GoldsparkIT.OCPP;

public abstract class JsonHandler
{
    public delegate Task<TResponse> RequestEventHandler<in TRequest, TResponse>(TRequest request);

    public delegate Task RequestEventHandler<in TRequest>(TRequest request);

    public delegate Task SendMessageDelegate(string message);

    private readonly ConcurrentDictionary<string, TaskCompletionSource<JsonPayloadWrapper>> _activeRequests = new();

    private readonly SemaphoreSlim _requestSemaphore = new(1);

    protected readonly ILogger Logger;

    private protected JsonHandler(ILogger logger)
    {
        Logger = logger;
    }

    public event SendMessageDelegate? OnSendMessage;

    public async Task HandleMessage(string message)
    {
        TaskCompletionSource<JsonPayloadWrapper>? request;

        var msg = JsonWrapper.FromJson(message);

        switch (msg.MessageTypeId)
        {
            case MessageType.Call:
                var response = await ProcessRequest(message);

                await SendMessage(response);

                break;
            case MessageType.CallResult:
                if (_activeRequests.TryGetValue(msg.UniqueId, out request))
                {
                    request.SetResult(JsonPayloadWrapper.FromJson(message));
                }
                else
                {
                    throw new NoActiveRequestFoundException(msg.UniqueId);
                }

                break;
            case MessageType.CallError:
                if (_activeRequests.TryGetValue(msg.UniqueId, out request))
                {
                    var error = JsonErrorWrapper.FromJson(message);

                    var exception = new RemoteOperationException(error.ErrorCode, error.ErrorDescription, error.ErrorDetails);

                    request.SetException(exception);
                }
                else
                {
                    throw new NoActiveRequestFoundException(msg.UniqueId);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(msg.MessageTypeId));
        }
    }

    protected abstract Task<string> ProcessRequest(string message);

    protected async Task<TResponse> DoRequest<TRequest, TResponse>(TRequest request, Enums.Action action, CancellationToken? cancellationToken = null)
    {
        if (cancellationToken != null)
        {
            await _requestSemaphore.WaitAsync((CancellationToken)cancellationToken);
        }
        else
        {
            await _requestSemaphore.WaitAsync();
        }

        var uniqueId = Guid.NewGuid().ToString("D");

        var tcs = new TaskCompletionSource<JsonPayloadWrapper>();

        _activeRequests.TryAdd(uniqueId, tcs);

        try
        {
            await SendMessage(SerializeRequest(request, uniqueId, action));

            if (cancellationToken != null)
            {
                if (await Task.WhenAny(tcs.Task, Task.FromCanceled((CancellationToken)cancellationToken)) != tcs.Task)
                {
                    throw new OperationCanceledException((CancellationToken)cancellationToken);
                }
            }
            else
            {
                await tcs.Task;
            }

            var response = tcs.Task.Result;

            return response.Payload.ToObject<TResponse>() ?? throw new SerializationException($"Could not parse payload as {nameof(TResponse)}");
        }
        finally
        {
            _activeRequests.TryRemove(uniqueId, out _);

            _requestSemaphore.Release();
        }
    }

    protected async Task DoRequest<TRequest>(TRequest request, Enums.Action action, CancellationToken? cancellationToken = null)
    {
        if (cancellationToken != null)
        {
            await _requestSemaphore.WaitAsync((CancellationToken)cancellationToken);
        }
        else
        {
            await _requestSemaphore.WaitAsync();
        }

        var uniqueId = Guid.NewGuid().ToString("D");

        var tcs = new TaskCompletionSource<JsonPayloadWrapper>();

        _activeRequests.TryAdd(uniqueId, tcs);

        try
        {
            await SendMessage(SerializeRequest(request, uniqueId, action));

            if (cancellationToken != null)
            {
                if (await Task.WhenAny(tcs.Task, Task.FromCanceled((CancellationToken)cancellationToken)) != tcs.Task)
                {
                    throw new OperationCanceledException((CancellationToken)cancellationToken);
                }
            }
            else
            {
                await tcs.Task;
            }
        }
        finally
        {
            _activeRequests.TryRemove(uniqueId, out _);

            _requestSemaphore.Release();
        }
    }

    internal static async Task<string> HandleRequest<TRequest, TResponse>(JsonPayloadWrapper request, RequestEventHandler<TRequest, TResponse>? handler)
    {
        if (handler == null)
        {
            return SerializeErrorResponse("Not implemented", request.UniqueId, errorCode: ErrorCode.NotImplemented);
        }

        try
        {
            var result = await handler(request.Payload.ToObject<TRequest>() ?? throw new SerializationException($"Could not parse payload as {nameof(TRequest)}"));

            return SerializeResponse(result, request.UniqueId);
        }
        catch (NotImplementedException ex)
        {
            return SerializeErrorResponse(ex.Message, request.UniqueId, errorCode: ErrorCode.NotImplemented);
        }
        catch (Exception ex)
        {
            return SerializeErrorResponse(ex.Message, request.UniqueId);
        }
    }

    internal static async Task<string> HandleRequest<TRequest>(JsonPayloadWrapper request, RequestEventHandler<TRequest>? handler)
    {
        if (handler == null)
        {
            return SerializeResponse(new object(), request.UniqueId);
        }

        try
        {
            await handler(request.Payload.ToObject<TRequest>() ?? throw new SerializationException($"Could not parse payload as {nameof(TRequest)}"));

            return SerializeResponse(new object(), request.UniqueId);
        }
        catch (NotImplementedException ex)
        {
            return SerializeErrorResponse(ex.Message, request.UniqueId, errorCode: ErrorCode.NotImplemented);
        }
        catch (Exception ex)
        {
            return SerializeErrorResponse(ex.Message, request.UniqueId);
        }
    }

    private static string SerializeRequest<TRequest>(TRequest result, string uniqueId, Enums.Action action)
    {
        var requestMsg = new JsonRequestWrapper(
            MessageType.Call,
            uniqueId,
            action,
            JObject.FromObject(result ?? throw new SerializationException("Could not serialize null payload"))
        );

        return requestMsg.ToJson();
    }

    private static string SerializeResponse<TResponse>(TResponse result, string uniqueId)
    {
        var responseMsg = new JsonPayloadWrapper(
            MessageType.CallResult,
            uniqueId,
            JObject.FromObject(result ?? throw new SerializationException("Could not serialize null payload"))
        );

        return responseMsg.ToJson();
    }

    private static string SerializeErrorResponse(string errorMessage, string uniqueId, object? errorDetails = null, ErrorCode errorCode = ErrorCode.InternalError)
    {
        var responseMsg = new JsonErrorWrapper(
            MessageType.CallError,
            uniqueId,
            errorCode,
            errorMessage,
            JObject.FromObject(errorDetails ?? new object())
        );

        return responseMsg.ToJson();
    }

    private async Task SendMessage(string message)
    {
        if (OnSendMessage == null)
        {
            throw new NoSendMessageHandlerSetException();
        }

        await OnSendMessage(message);
    }
}
