using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Enums;

public enum SampledValuePhase
{
    [EnumMember(Value = @"L1")]
    L1 = 0,

    [EnumMember(Value = @"L2")]
    L2 = 1,

    [EnumMember(Value = @"L3")]
    L3 = 2,

    [EnumMember(Value = @"N")]
    N = 3,

    [EnumMember(Value = @"L1-N")]
    L1N = 4,

    [EnumMember(Value = @"L2-N")]
    L2N = 5,

    [EnumMember(Value = @"L3-N")]
    L3N = 6,

    [EnumMember(Value = @"L1-L2")]
    L1L2 = 7,

    [EnumMember(Value = @"L2-L3")]
    L2L3 = 8,

    [EnumMember(Value = @"L3-L1")]
    L3L1 = 9
}
