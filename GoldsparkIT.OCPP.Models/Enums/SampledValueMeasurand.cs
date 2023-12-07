using System.Runtime.Serialization;

namespace GoldsparkIT.OCPP.Models.Enums;

public enum SampledValueMeasurand
{
    [EnumMember(Value = @"Energy.Active.Export.Register")]
    Energy_Active_Export_Register = 0,

    [EnumMember(Value = @"Energy.Active.Import.Register")]
    Energy_Active_Import_Register = 1,

    [EnumMember(Value = @"Energy.Reactive.Export.Register")]
    Energy_Reactive_Export_Register = 2,

    [EnumMember(Value = @"Energy.Reactive.Import.Register")]
    Energy_Reactive_Import_Register = 3,

    [EnumMember(Value = @"Energy.Active.Export.Interval")]
    Energy_Active_Export_Interval = 4,

    [EnumMember(Value = @"Energy.Active.Import.Interval")]
    Energy_Active_Import_Interval = 5,

    [EnumMember(Value = @"Energy.Reactive.Export.Interval")]
    Energy_Reactive_Export_Interval = 6,

    [EnumMember(Value = @"Energy.Reactive.Import.Interval")]
    Energy_Reactive_Import_Interval = 7,

    [EnumMember(Value = @"Power.Active.Export")]
    Power_Active_Export = 8,

    [EnumMember(Value = @"Power.Active.Import")]
    Power_Active_Import = 9,

    [EnumMember(Value = @"Power.Offered")]
    Power_Offered = 10,

    [EnumMember(Value = @"Power.Reactive.Export")]
    Power_Reactive_Export = 11,

    [EnumMember(Value = @"Power.Reactive.Import")]
    Power_Reactive_Import = 12,

    [EnumMember(Value = @"Power.Factor")]
    Power_Factor = 13,

    [EnumMember(Value = @"Current.Import")]
    Current_Import = 14,

    [EnumMember(Value = @"Current.Export")]
    Current_Export = 15,

    [EnumMember(Value = @"Current.Offered")]
    Current_Offered = 16,

    [EnumMember(Value = @"Voltage")]
    Voltage = 17,

    [EnumMember(Value = @"Frequency")]
    Frequency = 18,

    [EnumMember(Value = @"Temperature")]
    Temperature = 19,

    [EnumMember(Value = @"SoC")]
    SoC = 20,

    [EnumMember(Value = @"RPM")]
    RPM = 21
}
