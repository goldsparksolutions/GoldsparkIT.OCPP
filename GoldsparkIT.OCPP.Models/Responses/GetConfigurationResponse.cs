using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Responses;

public record GetConfigurationResponse
{
    [JsonProperty("configurationKey", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<ConfigurationKey>? ConfigurationKey { get; init; }

    [JsonProperty("unknownKey", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ICollection<string>? UnknownKey { get; init; }
}
