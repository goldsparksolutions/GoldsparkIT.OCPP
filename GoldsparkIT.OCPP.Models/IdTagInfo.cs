using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models;

public record IdTagInfo(
    [property: JsonProperty("status", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: JsonConverter(typeof(StringEnumConverter))]
    IdTagInfoStatus Status)
{
    [JsonProperty("expiryDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? ExpiryDate { get; init; }

    [JsonProperty("parentIdTag", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(20)]
    public string? ParentIdTag { get; init; }
}
