using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Requests.Enums;

[GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v9.0.0.0)")]
public enum DiagnosticsStatusNotificationRequestStatus
{
    [EnumMember(Value = @"Idle")]
    Idle = 0,

    [EnumMember(Value = @"Uploaded")]
    Uploaded = 1,

    [EnumMember(Value = @"UploadFailed")]
    UploadFailed = 2,

    [EnumMember(Value = @"Uploading")]
    Uploading = 3
}
