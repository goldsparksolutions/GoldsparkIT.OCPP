using System.Runtime.Serialization;
using GoldsparkIT.OCPP.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoldsparkIT.OCPP.Models;

internal record JsonErrorWrapper : JsonWrapper
{
    public JsonErrorWrapper(MessageType messageTypeId, string uniqueId, ErrorCode errorCode, string errorDescription, JObject errorDetails) : base(messageTypeId, uniqueId)
    {
        ErrorCode = errorCode;
        ErrorDescription = errorDescription;
        ErrorDetails = errorDetails;
    }

    public ErrorCode ErrorCode { get; set; }

    public string ErrorDescription { get; set; }

    public JObject ErrorDetails { get; set; }

    public new static JsonErrorWrapper FromJson(string json)
    {
        var arrayData = JsonConvert.DeserializeObject<JArray>(json) ?? throw new SerializationException("Could not deserialize message");

        return new JsonErrorWrapper(
            arrayData[0].ToObject<MessageType>(),
            arrayData[1].ToString(),
            arrayData[2].ToObject<ErrorCode>(),
            arrayData[3].ToString(),
            arrayData[4].ToObject<JObject>() ?? []
        );
    }

    public override string ToJson()
    {
        return JsonConvert.SerializeObject(new object[]
        {
            MessageTypeId,
            UniqueId,
            ErrorCode,
            ErrorDescription,
            ErrorDetails
        });
    }
}
