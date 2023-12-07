using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Enums;

public enum ChargingScheduleChargingRateUnit
{
    [EnumMember(Value = @"A")]
    A = 0,

    [EnumMember(Value = @"W")]
    W = 1
}
