using GoldsparkIT.OCPP.Models.Requests.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models.Requests;

public record ClearChargingProfileRequest
{
    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int? Id { get; init; }

    [JsonProperty("connectorId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int? ConnectorId { get; init; }

    [JsonProperty("chargingProfilePurpose", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ClearChargingProfileRequestChargingProfilePurpose? ChargingProfilePurpose { get; init; }

    [JsonProperty("stackLevel", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int? StackLevel { get; init; }
}
