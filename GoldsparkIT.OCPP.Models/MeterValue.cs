using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models;

public record MeterValue(
    [property: JsonProperty("timestamp", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    DateTimeOffset Timestamp,
    [property: JsonProperty("sampledValue", Required = Required.Always)]
    [property: Required]
    ICollection<SampledValue> SampledValue);
