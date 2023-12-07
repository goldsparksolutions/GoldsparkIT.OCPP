using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoldsparkIT.OCPP.Models.Responses;

public record AuthorizeResponse(
    [property: JsonProperty("idTagInfo", Required = Required.Always)]
    [property: Required]
    IdTagInfo IdTagInfo);
