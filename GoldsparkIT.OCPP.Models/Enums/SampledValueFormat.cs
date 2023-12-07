using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Enums;

public enum SampledValueFormat
{
    [EnumMember(Value = @"Raw")]
    Raw = 0,

    [EnumMember(Value = @"SignedData")]
    SignedData = 1
}
