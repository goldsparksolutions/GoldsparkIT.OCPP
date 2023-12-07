using System.Runtime.Serialization;
using GoldsparkIT.OCPP.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoldsparkIT.OCPP.Models;

internal record JsonPayloadWrapper : JsonWrapper
{
    public JsonPayloadWrapper(MessageType messageTypeId, string uniqueId, JObject payload) : base(messageTypeId, uniqueId)
    {
        Payload = payload;
    }

    public JObject Payload { get; set; }

    public new static JsonPayloadWrapper FromJson(string json)
    {
        var arrayData = JsonConvert.DeserializeObject<JArray>(json) ?? throw new SerializationException("Could not deserialize message");

        return new JsonPayloadWrapper(
            arrayData[0].ToObject<MessageType>(),
            arrayData[1].ToString(),
            arrayData[2].ToObject<JObject>() ?? throw new SerializationException("Could not deserialize payload")
        );
    }

    public override string ToJson()
    {
        return JsonConvert.SerializeObject(new object?[]
        {
            MessageTypeId,
            UniqueId,
            Payload
        });
    }
}
