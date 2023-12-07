using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Requests;

public record CancelReservationRequest(
    [property: JsonProperty("reservationId", Required = Required.Always)]
    int ReservationId);
