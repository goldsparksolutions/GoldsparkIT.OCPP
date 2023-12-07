using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Enums;

public enum SampledValueUnit
{
    [EnumMember(Value = @"Wh")]
    Wh = 0,

    [EnumMember(Value = @"kWh")]
    KWh = 1,

    [EnumMember(Value = @"varh")]
    Varh = 2,

    [EnumMember(Value = @"kvarh")]
    Kvarh = 3,

    [EnumMember(Value = @"W")]
    W = 4,

    [EnumMember(Value = @"kW")]
    KW = 5,

    [EnumMember(Value = @"VA")]
    VA = 6,

    [EnumMember(Value = @"kVA")]
    KVA = 7,

    [EnumMember(Value = @"var")]
    Var = 8,

    [EnumMember(Value = @"kvar")]
    Kvar = 9,

    [EnumMember(Value = @"A")]
    A = 10,

    [EnumMember(Value = @"V")]
    V = 11,

    [EnumMember(Value = @"K")]
    K = 12,

    [EnumMember(Value = @"Celcius")]
    Celcius = 13,

    [EnumMember(Value = @"Celsius")]
    Celsius = 14,

    [EnumMember(Value = @"Fahrenheit")]
    Fahrenheit = 15,

    [EnumMember(Value = @"Percent")]
    Percent = 16
}
