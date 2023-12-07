using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Responses.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models.Responses;

public record DataTransferResponse(
    [property: JsonProperty("status", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: JsonConverter(typeof(StringEnumConverter))]
    DataTransferResponseStatus Status)
{
    [JsonProperty("data", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string? Data { get; init; }
}
