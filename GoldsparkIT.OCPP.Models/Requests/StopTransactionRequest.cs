using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Requests.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models.Requests;

public record StopTransactionRequest(
    [property: JsonProperty("meterStop", Required = Required.Always)]
    int MeterStop,
    [property: JsonProperty("timestamp", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    DateTimeOffset Timestamp,
    [property: JsonProperty("transactionId", Required = Required.Always)]
    int TransactionId)
{
    [JsonProperty("idTag", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(20)]
    public string? IdTag { get; init; }

    [JsonProperty("reason", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public StopTransactionRequestReason? Reason { get; init; }

    [JsonProperty("transactionData", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<TransactionData>? TransactionData { get; init; }
}
