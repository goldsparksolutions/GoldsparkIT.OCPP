using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models;

public record SampledValue(
    [property: JsonProperty("value", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    string Value)
{
    [JsonProperty("context", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SampledValueContext? Context { get; init; }

    [JsonProperty("format", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SampledValueFormat? Format { get; init; }

    [JsonProperty("measurand", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SampledValueMeasurand? Measurand { get; init; }

    [JsonProperty("phase", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SampledValuePhase? Phase { get; init; }

    [JsonProperty("location", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SampledValueLocation? Location { get; init; }

    [JsonProperty("unit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SampledValueUnit? Unit { get; init; }
}
