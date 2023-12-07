using GoldsparkIT.OCPP.Models;
using GoldsparkIT.OCPP.Models.Requests;
using GoldsparkIT.OCPP.Models.Responses;
using Microsoft.Extensions.Logging;
using Action = GoldsparkIT.OCPP.Enums.Action;

namespace GoldsparkIT.OCPP;

public class JsonChargePointHandler : JsonHandler
{
    public JsonChargePointHandler(ILogger<JsonChargePointHandler> logger) : base(logger)
    {
    }

    public event RequestEventHandler<CancelReservationRequest, CancelReservationResponse>? OnCancelReservation;

    public event RequestEventHandler<ChangeAvailabilityRequest, ChangeAvailabilityResponse>? OnChangeAvailability;

    public event RequestEventHandler<ChangeConfigurationRequest, ChangeConfigurationResponse>? OnChangeConfiguration;

    public event RequestEventHandler<ClearCacheRequest, ClearCacheResponse>? OnClearCache;

    public event RequestEventHandler<ClearChargingProfileRequest, ClearChargingProfileResponse>? OnClearChargingProfile;

    public event RequestEventHandler<DataTransferRequest, DataTransferResponse>? OnDataTransfer;

    public event RequestEventHandler<GetCompositeScheduleRequest, GetCompositeScheduleResponse>? OnGetCompositeSchedule;

    public event RequestEventHandler<GetConfigurationRequest, GetConfigurationResponse>? OnGetConfiguration;

    public event RequestEventHandler<GetDiagnosticsRequest, GetDiagnosticsResponse>? OnGetDiagnostics;

    public event RequestEventHandler<GetLocalListVersionRequest, GetLocalListVersionResponse>? OnGetLocalListVersion;

    public event RequestEventHandler<RemoteStartTransactionRequest, RemoteStartTransactionResponse>? OnRemoteStartTransaction;

    public event RequestEventHandler<RemoteStopTransactionRequest, RemoteStopTransactionResponse>? OnRemoteStopTransaction;

    public event RequestEventHandler<ReserveNowRequest, ReserveNowResponse>? OnReserveNow;

    public event RequestEventHandler<ResetRequest, ResetResponse>? OnReset;

    public event RequestEventHandler<SendLocalListRequest, SendLocalListResponse>? OnSendLocalList;

    public event RequestEventHandler<SetChargingProfileRequest, SetChargingProfileResponse>? OnSetChargingProfile;

    public event RequestEventHandler<TriggerMessageRequest, TriggerMessageResponse>? OnTriggerMessage;

    public event RequestEventHandler<UnlockConnectorRequest, UnlockConnectorResponse>? OnUnlockConnector;

    public event RequestEventHandler<UpdateFirmwareRequest>? OnUpdateFirmware;

    public async Task<AuthorizeResponse> Authorize(AuthorizeRequest request)
    {
        return await DoRequest<AuthorizeRequest, AuthorizeResponse>(request, Action.Authorize);
    }

    public async Task<BootNotificationResponse> BootNotification(BootNotificationRequest request)
    {
        return await DoRequest<BootNotificationRequest, BootNotificationResponse>(request, Action.BootNotification);
    }

    public async Task<DataTransferResponse> DataTransfer(DataTransferRequest request)
    {
        return await DoRequest<DataTransferRequest, DataTransferResponse>(request, Action.DataTransfer);
    }

    public async Task DiagnosticsStatusNotification(DiagnosticsStatusNotificationRequest request)
    {
        await DoRequest(request, Action.DiagnosticsStatusNotification);
    }

    public async Task FirmwareStatusNotification(FirmwareStatusNotificationRequest request)
    {
        await DoRequest(request, Action.FirmwareStatusNotification);
    }

    public async Task<HeartbeatResponse> Heartbeat(HeartbeatRequest request)
    {
        return await DoRequest<HeartbeatRequest, HeartbeatResponse>(request, Action.Heartbeat);
    }

    public async Task MeterValues(MeterValuesRequest request)
    {
        await DoRequest(request, Action.MeterValues);
    }

    public async Task<StartTransactionResponse> StartTransaction(StartTransactionRequest request)
    {
        return await DoRequest<StartTransactionRequest, StartTransactionResponse>(request, Action.StartTransaction);
    }

    public async Task StatusNotification(StatusNotificationRequest request)
    {
        await DoRequest(request, Action.StatusNotification);
    }

    public async Task<StopTransactionResponse> StopTransaction(StopTransactionRequest request)
    {
        return await DoRequest<StopTransactionRequest, StopTransactionResponse>(request, Action.StopTransaction);
    }

    protected override async Task<string> ProcessRequest(string message)
    {
        var msg = JsonRequestWrapper.FromJson(message);

        return msg.Action switch
        {
            Action.CancelReservation => await HandleRequest(msg, OnCancelReservation),
            Action.ChangeAvailability => await HandleRequest(msg, OnChangeAvailability),
            Action.ChangeConfiguration => await HandleRequest(msg, OnChangeConfiguration),
            Action.ClearCache => await HandleRequest(msg, OnClearCache),
            Action.ClearChargingProfile => await HandleRequest(msg, OnClearChargingProfile),
            Action.DataTransfer => await HandleRequest(msg, OnDataTransfer),
            Action.GetCompositeSchedule => await HandleRequest(msg, OnGetCompositeSchedule),
            Action.GetConfiguration => await HandleRequest(msg, OnGetConfiguration),
            Action.GetDiagnostics => await HandleRequest(msg, OnGetDiagnostics),
            Action.GetLocalListVersion => await HandleRequest(msg, OnGetLocalListVersion),
            Action.RemoteStartTransaction => await HandleRequest(msg, OnRemoteStartTransaction),
            Action.RemoteStopTransaction => await HandleRequest(msg, OnRemoteStopTransaction),
            Action.ReserveNow => await HandleRequest(msg, OnReserveNow),
            Action.Reset => await HandleRequest(msg, OnReset),
            Action.SendLocalList => await HandleRequest(msg, OnSendLocalList),
            Action.SetChargingProfile => await HandleRequest(msg, OnSetChargingProfile),
            Action.TriggerMessage => await HandleRequest(msg, OnTriggerMessage),
            Action.UnlockConnector => await HandleRequest(msg, OnUnlockConnector),
            Action.UpdateFirmware => await HandleRequest(msg, OnUpdateFirmware),
            _ => throw new ArgumentOutOfRangeException(nameof(msg.Action), "Unknown action type")
        };
    }
}
