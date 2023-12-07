using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Responses.Enums;

[GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v9.0.0.0)")]
public record ChargingSchedulePeriod
{
    [JsonConstructor]
    public ChargingSchedulePeriod(double limit, int? numberPhases, int startPeriod)

    {
        StartPeriod = startPeriod;

        Limit = limit;

        NumberPhases = numberPhases;
    }

    [JsonProperty("startPeriod", Required = Required.Always)]
    public int StartPeriod { get; init; }

    [JsonProperty("limit", Required = Required.Always)]
    public double Limit { get; init; }

    [JsonProperty("numberPhases", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int? NumberPhases { get; init; }
}
