using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Requests.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models.Requests;

public record SendLocalListRequest(
    [property: JsonProperty("listVersion", Required = Required.Always)]
    int ListVersion,
    [property: JsonProperty("updateType", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: JsonConverter(typeof(StringEnumConverter))]
    SendLocalListRequestUpdateType UpdateType)
{
    [JsonProperty("localAuthorizationList", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<LocalAuthorizationList>? LocalAuthorizationList { get; init; }
}
