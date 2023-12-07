using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Requests;

public record RemoteStopTransactionRequest(
    [property: JsonProperty("transactionId", Required = Required.Always)]
    int TransactionId);
