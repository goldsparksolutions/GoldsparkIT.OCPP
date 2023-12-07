using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Enums;

public enum ResetRequestType
{
    [EnumMember(Value = @"Hard")]
    Hard = 0,

    [EnumMember(Value = @"Soft")]
    Soft = 1
}
