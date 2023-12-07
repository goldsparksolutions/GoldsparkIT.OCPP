using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Requests;

public record UnlockConnectorRequest(
    [property: JsonProperty("connectorId", Required = Required.Always)]
    int ConnectorId);
