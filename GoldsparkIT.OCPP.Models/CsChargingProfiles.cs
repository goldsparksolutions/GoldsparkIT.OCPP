using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models;

public record CsChargingProfiles(
    [property: JsonProperty("chargingSchedule", Required = Required.Always)]
    [property: Required]
    ChargingSchedule ChargingSchedule,
    [property: JsonProperty("chargingProfileId", Required = Required.Always)]
    int ChargingProfileId,
    [property: JsonProperty("stackLevel", Required = Required.Always)]
    int StackLevel,
    [property: JsonProperty("chargingProfilePurpose", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: JsonConverter(typeof(StringEnumConverter))]
    CsChargingProfilesChargingProfilePurpose ChargingProfilePurpose,
    [property: JsonProperty("chargingProfileKind", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: JsonConverter(typeof(StringEnumConverter))]
    CsChargingProfilesChargingProfileKind ChargingProfileKind)
{
    [JsonProperty("transactionId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int? TransactionId { get; init; }

    [JsonProperty("recurrencyKind", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public CsChargingProfilesRecurrencyKind? RecurrencyKind { get; init; }

    [JsonProperty("validFrom", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? ValidFrom { get; init; }

    [JsonProperty("validTo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? ValidTo { get; init; }
}
