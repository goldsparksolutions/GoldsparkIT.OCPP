using System.Runtime.Serialization;
using GoldsparkIT.OCPP.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoldsparkIT.OCPP.Models;

internal record JsonWrapper
{
    public JsonWrapper(MessageType messageTypeId, string uniqueId)
    {
        MessageTypeId = messageTypeId;
        UniqueId = uniqueId;
    }

    public MessageType MessageTypeId { get; set; }

    public string UniqueId { get; set; }

    public static JsonWrapper FromJson(string json)
    {
        var arrayData = JsonConvert.DeserializeObject<JArray>(json) ?? throw new SerializationException("Could not deserialize message");

        return new JsonWrapper(
            arrayData[0].ToObject<MessageType>(),
            arrayData[1].ToString()
        );
    }

    public virtual string ToJson()
    {
        return JsonConvert.SerializeObject(new object[]
        {
            MessageTypeId,
            UniqueId
        });
    }
}
