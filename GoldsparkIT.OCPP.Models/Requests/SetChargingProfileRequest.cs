using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Requests;

public record SetChargingProfileRequest(
    [property: JsonProperty("connectorId", Required = Required.Always)]
    int ConnectorId,
    [property: JsonProperty("csChargingProfiles", Required = Required.Always)]
    [property: Required]
    CsChargingProfiles CsChargingProfiles);
