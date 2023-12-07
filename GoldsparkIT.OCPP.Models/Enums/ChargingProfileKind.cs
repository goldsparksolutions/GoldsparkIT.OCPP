using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Enums;

public enum ChargingProfileKind
{
    [EnumMember(Value = @"Absolute")]
    Absolute = 0,

    [EnumMember(Value = @"Recurring")]
    Recurring = 1,

    [EnumMember(Value = @"Relative")]
    Relative = 2
}
