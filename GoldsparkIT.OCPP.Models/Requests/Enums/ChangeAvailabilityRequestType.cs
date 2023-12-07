using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Requests.Enums;

[GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v9.0.0.0)")]
public enum ChangeAvailabilityRequestType
{
    [EnumMember(Value = @"Inoperative")]
    Inoperative = 0,

    [EnumMember(Value = @"Operative")]
    Operative = 1
}
