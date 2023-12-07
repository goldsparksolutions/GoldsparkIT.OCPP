using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Requests.Enums;

[GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v9.0.0.0)")]
public enum SendLocalListRequestUpdateType
{
    [EnumMember(Value = @"Differential")]
    Differential = 0,

    [EnumMember(Value = @"Full")]
    Full = 1
}
