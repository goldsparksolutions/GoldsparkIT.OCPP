using GoldsparkIT.OCPP.Models;
using GoldsparkIT.OCPP.Models.Requests;
using GoldsparkIT.OCPP.Models.Responses;
using Microsoft.Extensions.Logging;
using Action = GoldsparkIT.OCPP.Enums.Action;

namespace GoldsparkIT.OCPP;

public class JsonServerHandler : JsonHandler
{
    public JsonServerHandler(ILogger<JsonServerHandler> logger) : base(logger)
    {
    }

    public event RequestEventHandler<AuthorizeRequest, AuthorizeResponse>? OnAuthorize;

    public event RequestEventHandler<BootNotificationRequest, BootNotificationResponse>? OnBootNotification;

    public event RequestEventHandler<DataTransferRequest, DataTransferResponse>? OnDataTransfer;

    public event RequestEventHandler<DiagnosticsStatusNotificationRequest>? OnDiagnosticsStatusNotification;

    public event RequestEventHandler<FirmwareStatusNotificationRequest>? OnFirmwareStatusNotification;

    public event RequestEventHandler<HeartbeatRequest, HeartbeatResponse>? OnHeartbeat;

    public event RequestEventHandler<MeterValuesRequest>? OnMeterValues;

    public event RequestEventHandler<StartTransactionRequest, StartTransactionResponse>? OnStartTransaction;

    public event RequestEventHandler<StatusNotificationRequest>? OnStatusNotification;

    public event RequestEventHandler<StopTransactionRequest, StopTransactionResponse>? OnStopTransaction;

    public async Task<CancelReservationResponse> CancelReservation(CancelReservationRequest request)
    {
        return await DoRequest<CancelReservationRequest, CancelReservationResponse>(request, Action.CancelReservation);
    }

    public async Task<ChangeAvailabilityResponse> ChangeAvailability(ChangeAvailabilityRequest request)
    {
        return await DoRequest<ChangeAvailabilityRequest, ChangeAvailabilityResponse>(request, Action.ChangeAvailability);
    }

    public async Task<ChangeConfigurationResponse> ChangeConfiguration(ChangeConfigurationRequest request)
    {
        return await DoRequest<ChangeConfigurationRequest, ChangeConfigurationResponse>(request, Action.ChangeConfiguration);
    }

    public async Task<ClearCacheResponse> ClearCache(ClearCacheRequest request)
    {
        return await DoRequest<ClearCacheRequest, ClearCacheResponse>(request, Action.ClearCache);
    }

    public async Task<ClearChargingProfileResponse> ClearChargingProfile(ClearChargingProfileRequest request)
    {
        return await DoRequest<ClearChargingProfileRequest, ClearChargingProfileResponse>(request, Action.ClearChargingProfile);
    }

    public async Task<DataTransferResponse> DataTransfer(DataTransferRequest request)
    {
        return await DoRequest<DataTransferRequest, DataTransferResponse>(request, Action.DataTransfer);
    }

    public async Task<GetCompositeScheduleResponse> GetCompositeSchedule(GetCompositeScheduleRequest request)
    {
        return await DoRequest<GetCompositeScheduleRequest, GetCompositeScheduleResponse>(request, Action.GetCompositeSchedule);
    }

    public async Task<GetConfigurationResponse> GetConfiguration(GetConfigurationRequest request)
    {
        return await DoRequest<GetConfigurationRequest, GetConfigurationResponse>(request, Action.GetConfiguration);
    }

    public async Task<GetDiagnosticsResponse> GetDiagnostics(GetDiagnosticsRequest request)
    {
        return await DoRequest<GetDiagnosticsRequest, GetDiagnosticsResponse>(request, Action.GetDiagnostics);
    }

    public async Task<GetLocalListVersionResponse> GetLocalListVersion(GetLocalListVersionRequest request)
    {
        return await DoRequest<GetLocalListVersionRequest, GetLocalListVersionResponse>(request, Action.GetLocalListVersion);
    }

    public async Task<RemoteStartTransactionResponse> RemoteStartTransaction(RemoteStartTransactionRequest request)
    {
        return await DoRequest<RemoteStartTransactionRequest, RemoteStartTransactionResponse>(request, Action.RemoteStartTransaction);
    }

    public async Task<RemoteStopTransactionResponse> RemoteStopTransaction(RemoteStopTransactionRequest request)
    {
        return await DoRequest<RemoteStopTransactionRequest, RemoteStopTransactionResponse>(request, Action.RemoteStopTransaction);
    }

    public async Task<ReserveNowResponse> ReserveNow(ReserveNowRequest request)
    {
        return await DoRequest<ReserveNowRequest, ReserveNowResponse>(request, Action.ReserveNow);
    }

    public async Task<ResetResponse> Reset(ResetRequest request)
    {
        return await DoRequest<ResetRequest, ResetResponse>(request, Action.Reset);
    }

    public async Task<SendLocalListResponse> SendLocalList(SendLocalListRequest request)
    {
        return await DoRequest<SendLocalListRequest, SendLocalListResponse>(request, Action.SendLocalList);
    }

    public async Task<SetChargingProfileResponse> SetChargingProfile(SetChargingProfileRequest request)
    {
        return await DoRequest<SetChargingProfileRequest, SetChargingProfileResponse>(request, Action.SetChargingProfile);
    }

    public async Task<TriggerMessageResponse> TriggerMessage(TriggerMessageRequest request)
    {
        return await DoRequest<TriggerMessageRequest, TriggerMessageResponse>(request, Action.TriggerMessage);
    }

    public async Task<UnlockConnectorResponse> UnlockConnector(UnlockConnectorRequest request)
    {
        return await DoRequest<UnlockConnectorRequest, UnlockConnectorResponse>(request, Action.UnlockConnector);
    }

    public async Task UpdateFirmware(UpdateFirmwareRequest request)
    {
        await DoRequest(request, Action.UpdateFirmware);
    }

    protected override async Task<string> ProcessRequest(string message)
    {
        var msg = JsonRequestWrapper.FromJson(message);

        return msg.Action switch
        {
            Action.Authorize => await HandleRequest(msg, OnAuthorize),
            Action.BootNotification => await HandleRequest(msg, OnBootNotification),
            Action.DataTransfer => await HandleRequest(msg, OnDataTransfer),
            Action.DiagnosticsStatusNotification => await HandleRequest(msg, OnDiagnosticsStatusNotification),
            Action.FirmwareStatusNotification => await HandleRequest(msg, OnFirmwareStatusNotification),
            Action.Heartbeat => await HandleRequest(msg, OnHeartbeat),
            Action.MeterValues => await HandleRequest(msg, OnMeterValues),
            Action.StartTransaction => await HandleRequest(msg, OnStartTransaction),
            Action.StatusNotification => await HandleRequest(msg, OnStatusNotification),
            Action.StopTransaction => await HandleRequest(msg, OnStopTransaction),
            _ => throw new ArgumentOutOfRangeException(nameof(msg.Action), "Unknown action type")
        };
    }
}
