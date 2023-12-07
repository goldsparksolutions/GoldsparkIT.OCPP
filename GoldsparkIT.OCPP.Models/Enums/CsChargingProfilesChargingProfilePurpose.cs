using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Enums;

public enum CsChargingProfilesChargingProfilePurpose
{
    [EnumMember(Value = @"ChargePointMaxProfile")]
    ChargePointMaxProfile = 0,

    [EnumMember(Value = @"TxDefaultProfile")]
    TxDefaultProfile = 1,

    [EnumMember(Value = @"TxProfile")]
    TxProfile = 2
}
