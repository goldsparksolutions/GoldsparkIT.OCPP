using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Requests;

public record UpdateFirmwareRequest(
    [property: JsonProperty("location", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    Uri Location,
    [property: JsonProperty("retrieveDate", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    DateTimeOffset RetrieveDate)
{
    [JsonProperty("retries", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int? Retries { get; init; }

    [JsonProperty("retryInterval", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int? RetryInterval { get; init; }
}
