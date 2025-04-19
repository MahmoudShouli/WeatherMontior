using System.Text.Json;

namespace WeatherMonitor.Util;

public static class HelperUtil
{
    public static T DeserializeJsonString<T>(string jsonString)
    {
        var deserializedObject = JsonSerializer.Deserialize<T>(jsonString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (deserializedObject != null)
            return deserializedObject;
        throw new Exception("Failed to deserialize.");
    }
}