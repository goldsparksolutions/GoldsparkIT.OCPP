using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Requests;

public record BootNotificationRequest(
    [property: JsonProperty("chargePointVendor", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: StringLength(20)]
    string ChargePointVendor,
    [property: JsonProperty("chargePointModel", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: StringLength(20)]
    string ChargePointModel)
{
    [JsonProperty("chargePointSerialNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(25)]
    public string? ChargePointSerialNumber { get; init; }

    [JsonProperty("chargeBoxSerialNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(25)]
    public string? ChargeBoxSerialNumber { get; init; }

    [JsonProperty("firmwareVersion", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(50)]
    public string? FirmwareVersion { get; init; }

    [JsonProperty("iccid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(20)]
    public string? Iccid { get; init; }

    [JsonProperty("imsi", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(20)]
    public string? Imsi { get; init; }

    [JsonProperty("meterType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(25)]
    public string? MeterType { get; init; }

    [JsonProperty("meterSerialNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(25)]
    public string? MeterSerialNumber { get; init; }
}
