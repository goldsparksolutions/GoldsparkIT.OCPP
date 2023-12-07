using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Requests.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models.Requests;

public record ChangeAvailabilityRequest(
    [property: JsonProperty("connectorId", Required = Required.Always)]
    int ConnectorId,
    [property: JsonProperty("type", Required = Required.Always)]
    [property: Required(AllowEmptyStrings = true)]
    [property: JsonConverter(typeof(StringEnumConverter))]
    ChangeAvailabilityRequestType Type);
