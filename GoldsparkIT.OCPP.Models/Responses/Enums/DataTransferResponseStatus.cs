using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Responses.Enums;

[GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v9.0.0.0)")]
public enum DataTransferResponseStatus
{
    [EnumMember(Value = @"Accepted")]
    Accepted = 0,

    [EnumMember(Value = @"Rejected")]
    Rejected = 1,

    [EnumMember(Value = @"UnknownMessageId")]
    UnknownMessageId = 2,

    [EnumMember(Value = @"UnknownVendorId")]
    UnknownVendorId = 3
}