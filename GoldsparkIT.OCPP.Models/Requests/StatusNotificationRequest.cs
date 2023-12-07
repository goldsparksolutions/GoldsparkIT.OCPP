using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Requests.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models.Requests;

public record StatusNotificationRequest(
    [property: JsonProperty("connectorId", Required = Required.Always)]
    int ConnectorId,
    [property: JsonProperty("errorCode", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: JsonConverter(typeof(StringEnumConverter))]
    StatusNotificationRequestErrorCode ErrorCode,
    [property: JsonProperty("status", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: JsonConverter(typeof(StringEnumConverter))]
    StatusNotificationRequestStatus Status)
{
    [JsonProperty("info", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(50)]
    public string? Info { get; init; }

    [JsonProperty("timestamp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? Timestamp { get; init; }

    [JsonProperty("vendorId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(255)]
    public string? VendorId { get; init; }

    [JsonProperty("vendorErrorCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(50)]
    public string? VendorErrorCode { get; init; }
}
