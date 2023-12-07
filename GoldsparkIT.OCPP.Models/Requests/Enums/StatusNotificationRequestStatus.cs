using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Requests.Enums;

[GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v9.0.0.0)")]
public enum StatusNotificationRequestStatus
{
    [EnumMember(Value = @"Available")]
    Available = 0,

    [EnumMember(Value = @"Preparing")]
    Preparing = 1,

    [EnumMember(Value = @"Charging")]
    Charging = 2,

    [EnumMember(Value = @"SuspendedEVSE")]
    SuspendedEVSE = 3,

    [EnumMember(Value = @"SuspendedEV")]
    SuspendedEV = 4,

    [EnumMember(Value = @"Finishing")]
    Finishing = 5,

    [EnumMember(Value = @"Reserved")]
    Reserved = 6,

    [EnumMember(Value = @"Unavailable")]
    Unavailable = 7,

    [EnumMember(Value = @"Faulted")]
    Faulted = 8
}
