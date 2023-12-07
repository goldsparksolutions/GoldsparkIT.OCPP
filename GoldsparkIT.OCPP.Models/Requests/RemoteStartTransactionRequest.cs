using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Requests;

public record RemoteStartTransactionRequest(
    [property: JsonProperty("idTag", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: StringLength(20)]
    string IdTag)
{
    [JsonProperty("connectorId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int? ConnectorId { get; init; }

    [JsonProperty("chargingProfile", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ChargingProfile? ChargingProfile { get; init; }
}
