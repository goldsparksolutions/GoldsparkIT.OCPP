using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Responses;

public record StopTransactionResponse
{
    [JsonProperty("idTagInfo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public IdTagInfo? IdTagInfo { get; init; }
}
