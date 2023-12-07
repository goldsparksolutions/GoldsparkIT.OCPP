using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Responses.Enums;

[GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v9.0.0.0)")]
public enum ReserveNowResponseStatus
{
    [EnumMember(Value = @"Accepted")]
    Accepted = 0,

    [EnumMember(Value = @"Faulted")]
    Faulted = 1,

    [EnumMember(Value = @"Occupied")]
    Occupied = 2,

    [EnumMember(Value = @"Rejected")]
    Rejected = 3,

    [EnumMember(Value = @"Unavailable")]
    Unavailable = 4
}
