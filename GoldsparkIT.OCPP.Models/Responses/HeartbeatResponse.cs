using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Responses;

public record HeartbeatResponse(
    [property: JsonProperty("currentTime", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    DateTimeOffset CurrentTime);
