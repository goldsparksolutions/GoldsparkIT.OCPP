using System.Runtime.Serialization;
using GoldsparkIT.OCPP.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Action = GoldsparkIT.OCPP.Enums.Action;

namespace GoldsparkIT.OCPP.Models;

internal record JsonRequestWrapper : JsonPayloadWrapper
{
    public JsonRequestWrapper(MessageType messageTypeId, string uniqueId, Action action, JObject payload) : base(messageTypeId, uniqueId, payload)
    {
        Action = action;
    }

    public Action Action { get; set; }

    public new static JsonRequestWrapper FromJson(string json)
    {
        var arrayData = JsonConvert.DeserializeObject<JArray>(json) ?? throw new SerializationException("Could not deserialize message");

        return new JsonRequestWrapper(
            arrayData[0].ToObject<MessageType>(),
            arrayData[1].ToString(),
            arrayData[2].ToObject<Action>(),
            arrayData[3].ToObject<JObject>() ?? throw new SerializationException("Could not deserialize payload")
        );
    }

    public override string ToJson()
    {
        return JsonConvert.SerializeObject(new object[]
        {
            MessageTypeId,
            UniqueId,
            Action,
            Payload
        });
    }
}
