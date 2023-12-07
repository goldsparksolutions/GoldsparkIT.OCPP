using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Responses.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models.Responses;

public record BootNotificationResponse(
    [property: JsonProperty("status", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: JsonConverter(typeof(StringEnumConverter))]
    BootNotificationResponseStatus Status,
    [property: JsonProperty("currentTime", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    DateTimeOffset CurrentTime,
    [property: JsonProperty("interval", Required = Required.Always)]
    int Interval);
