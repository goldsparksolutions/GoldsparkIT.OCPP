using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Requests;

public record StartTransactionRequest(
    [property: JsonProperty("connectorId", Required = Required.Always)]
    int ConnectorId,
    [property: JsonProperty("idTag", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: StringLength(20)]
    string IdTag,
    [property: JsonProperty("meterStart", Required = Required.Always)]
    int MeterStart,
    [property: JsonProperty("timestamp", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    DateTimeOffset Timestamp)
{
    [JsonProperty("reservationId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int? ReservationId { get; init; }
}
