using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Requests.Enums;

[GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v9.0.0.0)")]
public enum FirmwareStatusNotificationRequestStatus
{
    [EnumMember(Value = @"Downloaded")]
    Downloaded = 0,

    [EnumMember(Value = @"DownloadFailed")]
    DownloadFailed = 1,

    [EnumMember(Value = @"Downloading")]
    Downloading = 2,

    [EnumMember(Value = @"Idle")]
    Idle = 3,

    [EnumMember(Value = @"InstallationFailed")]
    InstallationFailed = 4,

    [EnumMember(Value = @"Installing")]
    Installing = 5,

    [EnumMember(Value = @"Installed")]
    Installed = 6
}
