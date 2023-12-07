using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models.Requests;

public record ResetRequest(
    [property: JsonProperty("type", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: JsonConverter(typeof(StringEnumConverter))]
    ResetRequestType Type);
