using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Requests;

public record GetDiagnosticsRequest(
    [property: JsonProperty("location", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    Uri Location)
{
    [JsonProperty("retries", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int? Retries { get; init; }

    [JsonProperty("retryInterval", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int? RetryInterval { get; init; }

    [JsonProperty("startTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? StartTime { get; init; }

    [JsonProperty("stopTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? StopTime { get; init; }
}
