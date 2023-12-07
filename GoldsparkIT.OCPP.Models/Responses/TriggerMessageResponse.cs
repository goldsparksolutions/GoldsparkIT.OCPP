using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Responses.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models.Responses;

public record TriggerMessageResponse(
    [property: JsonProperty("status", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: JsonConverter(typeof(StringEnumConverter))]
    TriggerMessageResponseStatus Status);
