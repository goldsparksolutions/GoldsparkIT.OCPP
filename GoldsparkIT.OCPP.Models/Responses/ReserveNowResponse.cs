using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Responses.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models.Responses;

public record ReserveNowResponse(
    [property: JsonProperty("status", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: JsonConverter(typeof(StringEnumConverter))]
    ReserveNowResponseStatus Status);
