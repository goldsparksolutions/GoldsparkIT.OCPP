using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Requests;

public record DataTransferRequest(
    [property: JsonProperty("vendorId", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: StringLength(255)]
    string VendorId)
{
    [JsonProperty("messageId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(50)]
    public string? MessageId { get; init; }

    [JsonProperty("data", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string? Data { get; init; }
}
