using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class GoalConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Goal);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JObject jsonObject = JObject.Load(reader);
        if (jsonObject.TryGetValue("Type", out JToken typeToken))
        {
            string typeName = typeToken.ToObject<string>();

            switch (typeName)
            {
                case "SimpleGoal":
                    return jsonObject.ToObject<SimpleGoal>();
                case "EternalGoal":
                    return jsonObject.ToObject<EternalGoal>();
                case "ChecklistGoal":
                    return jsonObject.ToObject<ChecklistGoal>();
                default:
                    throw new NotSupportedException($"Unsupported goal type: {typeName}");
            }
        }
        else
        {
            throw new JsonSerializationException("Missing 'Type' property in JSON object.");
        }
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
