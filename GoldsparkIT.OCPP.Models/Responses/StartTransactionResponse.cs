using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Responses;

public record StartTransactionResponse(
    [property: JsonProperty("idTagInfo", Required = Required.Always)]
    [property: Required]
    IdTagInfo IdTagInfo,
    [property: JsonProperty("transactionId", Required = Required.Always)]
    int TransactionId);
