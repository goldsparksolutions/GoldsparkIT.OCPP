using System.ComponentModel.DataAnnotations;
using GoldsparkIT.OCPP.Models.Requests.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Models.Requests;

public record FirmwareStatusNotificationRequest
{
    [JsonProperty("status", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(StringEnumConverter))]
    public FirmwareStatusNotificationRequestStatus Status { get; init; }
}
