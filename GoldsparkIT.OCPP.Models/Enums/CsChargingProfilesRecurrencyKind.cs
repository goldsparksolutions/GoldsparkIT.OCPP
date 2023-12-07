using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Enums;

public enum CsChargingProfilesRecurrencyKind
{
    [EnumMember(Value = @"Daily")]
    Daily = 0,

    [EnumMember(Value = @"Weekly")]
    Weekly = 1
}
