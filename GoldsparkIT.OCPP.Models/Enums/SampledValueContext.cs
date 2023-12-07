using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Enums;

public enum SampledValueContext
{
    [EnumMember(Value = @"Interruption.Begin")]
    Interruption_Begin = 0,

    [EnumMember(Value = @"Interruption.End")]
    Interruption_End = 1,

    [EnumMember(Value = @"Sample.Clock")]
    Sample_Clock = 2,

    [EnumMember(Value = @"Sample.Periodic")]
    Sample_Periodic = 3,

    [EnumMember(Value = @"Transaction.Begin")]
    Transaction_Begin = 4,

    [EnumMember(Value = @"Transaction.End")]
    Transaction_End = 5,

    [EnumMember(Value = @"Trigger")]
    Trigger = 6,

    [EnumMember(Value = @"Other")]
    Other = 7
}
