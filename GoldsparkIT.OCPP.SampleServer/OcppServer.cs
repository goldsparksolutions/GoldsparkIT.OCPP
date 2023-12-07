using System.Net.WebSockets;
using System.Text;
using GoldsparkIT.OCPP.Models;
using GoldsparkIT.OCPP.Models.Enums;
using GoldsparkIT.OCPP.Models.Requests;
using GoldsparkIT.OCPP.Models.Responses;
using GoldsparkIT.OCPP.Models.Responses.Enums;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.SampleServer;

public class OcppServer
{
    private readonly Guid _connectionId;
    private readonly ILogger<OcppServer> _logger;
    private readonly JsonServerHandler _ocppHandler;
    private readonly WebSocketHandler _webSocketHandler;

    public OcppServer(JsonServerHandler ocppHandler, ILogger<OcppServer> logger)
    {
        _logger = logger;

        _ocppHandler = ocppHandler;

        _connectionId = Guid.NewGuid();

        _webSocketHandler = new WebSocketHandler();
        _webSocketHandler.OnReceiveMessage += OnReceiveMessage;

        _ocppHandler.OnSendMessage += SendMessage;
        _ocppHandler.OnAuthorize += OnAuthorize;
        _ocppHandler.OnBootNotification += OnBootNotification;
        _ocppHandler.OnDataTransfer += OnDataTransfer;
        _ocppHandler.OnDiagnosticsStatusNotification += OnDiagnosticsStatusNotification;
        _ocppHandler.OnFirmwareStatusNotification += OnFirmwareStatusNotification;
        _ocppHandler.OnHeartbeat += OnHeartbeat;
        _ocppHandler.OnMeterValues += OnMeterValues;
        _ocppHandler.OnStartTransaction += OnStartTransaction;
        _ocppHandler.OnStatusNotification += OnStatusNotification;
        _ocppHandler.OnStopTransaction += OnStopTransaction;
    }

    private Task<AuthorizeResponse> OnAuthorize(AuthorizeRequest request)
    {
        _logger.LogInformation("[{connectionId}] Authorization request received: {req}", _connectionId, JsonConvert.SerializeObject(request));

        return Task.FromResult(new AuthorizeResponse(
            new IdTagInfo(IdTagInfoStatus.Accepted)
            {
                ExpiryDate = DateTimeOffset.Now.AddHours(1),
                ParentIdTag = null
            }
        ));
    }

    private Task<BootNotificationResponse> OnBootNotification(BootNotificationRequest request)
    {
        _logger.LogInformation("[{connectionId}] Boot notification request received: {req}", _connectionId, JsonConvert.SerializeObject(request));

        return Task.FromResult(new BootNotificationResponse(
            BootNotificationResponseStatus.Accepted,
            DateTimeOffset.Now,
            10
        ));
    }

    private Task<DataTransferResponse> OnDataTransfer(DataTransferRequest request)
    {
        _logger.LogInformation("[{connectionId}] Data transfer request received: {req}", _connectionId, JsonConvert.SerializeObject(request));

        return Task.FromResult(new DataTransferResponse(DataTransferResponseStatus.Rejected)
        {
            Data = ""
        });
    }

    private Task OnDiagnosticsStatusNotification(DiagnosticsStatusNotificationRequest request)
    {
        _logger.LogInformation("[{connectionId}] Diagnostics status notification request received: {req}", _connectionId, JsonConvert.SerializeObject(request));

        return Task.CompletedTask;
    }

    private Task OnFirmwareStatusNotification(FirmwareStatusNotificationRequest request)
    {
        _logger.LogInformation("[{connectionId}] Firmware status notification request received: {req}", _connectionId, JsonConvert.SerializeObject(request));

        return Task.CompletedTask;
    }

    private Task<HeartbeatResponse> OnHeartbeat(HeartbeatRequest request)
    {
        _logger.LogInformation("[{connectionId}] Heartbeat request received: {req}", _connectionId, JsonConvert.SerializeObject(request));

        return Task.FromResult(new HeartbeatResponse(DateTimeOffset.Now));
    }

    private Task OnMeterValues(MeterValuesRequest request)
    {
        _logger.LogInformation("[{connectionId}] Meter values request received: {req}", _connectionId, JsonConvert.SerializeObject(request));

        return Task.CompletedTask;
    }

    private Task<StartTransactionResponse> OnStartTransaction(StartTransactionRequest request)
    {
        _logger.LogInformation("[{connectionId}] Start transaction request received: {req}", _connectionId, JsonConvert.SerializeObject(request));

        return Task.FromResult(new StartTransactionResponse(
            new IdTagInfo(IdTagInfoStatus.Accepted)
            {
                ExpiryDate = DateTimeOffset.Now.AddHours(1),
                ParentIdTag = null
            },
            1
        ));
    }

    private Task OnStatusNotification(StatusNotificationRequest request)
    {
        _logger.LogInformation("[{connectionId}] Status notification request received: {req}", _connectionId, JsonConvert.SerializeObject(request));

        return Task.CompletedTask;
    }

    private Task<StopTransactionResponse> OnStopTransaction(StopTransactionRequest request)
    {
        _logger.LogInformation("[{connectionId}] Stop transaction request received: {req}", _connectionId, JsonConvert.SerializeObject(request));

        return Task.FromResult(new StopTransactionResponse
        {
            IdTagInfo = new IdTagInfo(IdTagInfoStatus.Accepted)
            {
                ExpiryDate = DateTimeOffset.Now.AddHours(1),
                ParentIdTag = null
            }
        });
    }

    private async Task OnReceiveMessage(byte[] data)
    {
        var msg = Encoding.UTF8.GetString(data);

        await _ocppHandler.HandleMessage(msg);
    }

    private async Task SendMessage(string message)
    {
        await _webSocketHandler.Send(message);
    }

    public void Start(WebSocket webSocket)
    {
        _webSocketHandler.Start(webSocket);
    }
}
