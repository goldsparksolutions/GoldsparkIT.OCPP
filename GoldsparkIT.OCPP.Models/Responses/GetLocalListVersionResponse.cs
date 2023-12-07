using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Responses;

public record GetLocalListVersionResponse(
    [property: JsonProperty("listVersion", Required = Required.Always)]
    int ListVersion);
