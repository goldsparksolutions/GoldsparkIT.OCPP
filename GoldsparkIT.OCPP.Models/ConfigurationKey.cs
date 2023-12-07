using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models;

public record ConfigurationKey(
    [property: JsonProperty("key", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: StringLength(50)]
    string Key,
    [property: JsonProperty("readonly", Required = Required.Always)]
    bool ReadOnly)
{
    [JsonProperty("value", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(500)]
    public string? Value { get; init; }
}
