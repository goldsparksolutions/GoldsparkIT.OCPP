using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Responses.Enums;

[GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v9.0.0.0)")]
public enum UnlockConnectorResponseStatus
{
    [EnumMember(Value = @"Unlocked")]
    Unlocked = 0,

    [EnumMember(Value = @"UnlockFailed")]
    UnlockFailed = 1,

    [EnumMember(Value = @"NotSupported")]
    NotSupported = 2
}
