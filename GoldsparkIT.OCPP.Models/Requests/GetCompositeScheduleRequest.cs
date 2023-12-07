using GoldsparkIT.OCPP.Models.Requests.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models.Requests;

public record GetCompositeScheduleRequest(
    [property: JsonProperty("connectorId", Required = Required.Always)]
    int ConnectorId,
    [property: JsonProperty("duration", Required = Required.Always)]
    int Duration)
{
    [JsonProperty("chargingRateUnit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public GetCompositeScheduleRequestChargingRateUnit? ChargingRateUnit { get; init; }
}
