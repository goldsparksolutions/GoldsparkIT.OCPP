using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Requests;

public record GetConfigurationRequest
{
    [JsonProperty("key", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string>? Key { get; init; }
}
