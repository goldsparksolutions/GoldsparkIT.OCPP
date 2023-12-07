using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Requests.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models.Requests;

public record TriggerMessageRequest(
    [property: JsonProperty("requestedMessage", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: JsonConverter(typeof(StringEnumConverter))]
    TriggerMessageRequestRequestedMessage RequestedMessage)
{
    [JsonProperty("connectorId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int? ConnectorId { get; init; }
}
