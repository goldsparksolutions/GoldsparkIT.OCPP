using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Requests.Enums;

[GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v9.0.0.0)")]
public enum TriggerMessageRequestRequestedMessage
{
    [EnumMember(Value = @"BootNotification")]
    BootNotification = 0,

    [EnumMember(Value = @"DiagnosticsStatusNotification")]
    DiagnosticsStatusNotification = 1,

    [EnumMember(Value = @"FirmwareStatusNotification")]
    FirmwareStatusNotification = 2,

    [EnumMember(Value = @"Heartbeat")]
    Heartbeat = 3,

    [EnumMember(Value = @"MeterValues")]
    MeterValues = 4,

    [EnumMember(Value = @"StatusNotification")]
    StatusNotification = 5
}
