using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Enums;

public enum IdTagInfoStatus
{
    [EnumMember(Value = @"Accepted")]
    Accepted = 0,

    [EnumMember(Value = @"Blocked")]
    Blocked = 1,

    [EnumMember(Value = @"Expired")]
    Expired = 2,

    [EnumMember(Value = @"Invalid")]
    Invalid = 3,

    [EnumMember(Value = @"ConcurrentTx")]
    ConcurrentTx = 4
}
