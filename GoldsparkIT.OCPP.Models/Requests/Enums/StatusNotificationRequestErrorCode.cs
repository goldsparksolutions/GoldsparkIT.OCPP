using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Requests.Enums;

[GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v9.0.0.0)")]
public enum StatusNotificationRequestErrorCode
{
    [EnumMember(Value = @"ConnectorLockFailure")]
    ConnectorLockFailure = 0,

    [EnumMember(Value = @"EVCommunicationError")]
    EVCommunicationError = 1,

    [EnumMember(Value = @"GroundFailure")]
    GroundFailure = 2,

    [EnumMember(Value = @"HighTemperature")]
    HighTemperature = 3,

    [EnumMember(Value = @"InternalError")]
    InternalError = 4,

    [EnumMember(Value = @"LocalListConflict")]
    LocalListConflict = 5,

    [EnumMember(Value = @"NoError")]
    NoError = 6,

    [EnumMember(Value = @"OtherError")]
    OtherError = 7,

    [EnumMember(Value = @"OverCurrentFailure")]
    OverCurrentFailure = 8,

    [EnumMember(Value = @"PowerMeterFailure")]
    PowerMeterFailure = 9,

    [EnumMember(Value = @"PowerSwitchFailure")]
    PowerSwitchFailure = 10,

    [EnumMember(Value = @"ReaderFailure")]
    ReaderFailure = 11,

    [EnumMember(Value = @"ResetFailure")]
    ResetFailure = 12,

    [EnumMember(Value = @"UnderVoltage")]
    UnderVoltage = 13,

    [EnumMember(Value = @"OverVoltage")]
    OverVoltage = 14,

    [EnumMember(Value = @"WeakSignal")]
    WeakSignal = 15
}
