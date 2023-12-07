using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Requests;

public record ChangeConfigurationRequest(
    [property: JsonProperty("key", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: StringLength(50)]
    string Key,
    [property: JsonProperty("value", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: StringLength(500)]
    string Value);
