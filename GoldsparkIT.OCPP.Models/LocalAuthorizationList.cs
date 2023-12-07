using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models;

public record LocalAuthorizationList(
    [property: JsonProperty("idTag", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: StringLength(20)]
    string IdTag)
{
    [JsonProperty("idTagInfo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IdTagInfo? IdTagInfo { get; init; }
}
