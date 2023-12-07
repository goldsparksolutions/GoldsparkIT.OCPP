using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Requests.Enums;

[GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v9.0.0.0)")]
public enum StopTransactionRequestReason
{
    [EnumMember(Value = @"EmergencyStop")]
    EmergencyStop = 0,

    [EnumMember(Value = @"EVDisconnected")]
    EVDisconnected = 1,

    [EnumMember(Value = @"HardReset")]
    HardReset = 2,

    [EnumMember(Value = @"Local")]
    Local = 3,

    [EnumMember(Value = @"Other")]
    Other = 4,

    [EnumMember(Value = @"PowerLoss")]
    PowerLoss = 5,

    [EnumMember(Value = @"Reboot")]
    Reboot = 6,

    [EnumMember(Value = @"Remote")]
    Remote = 7,

    [EnumMember(Value = @"SoftReset")]
    SoftReset = 8,

    [EnumMember(Value = @"UnlockCommand")]
    UnlockCommand = 9,

    [EnumMember(Value = @"DeAuthorized")]
    DeAuthorized = 10
}
