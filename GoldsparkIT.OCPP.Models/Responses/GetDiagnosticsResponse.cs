using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Responses;

public record GetDiagnosticsResponse
{
    [JsonProperty("fileName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(255)]
    public string? FileName { get; init; }
}
