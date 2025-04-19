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
    
    public static string DetectFormat(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Input is empty.");

        var trimmed = input.TrimStart();

        if (trimmed.StartsWith('{') || trimmed.StartsWith('['))
            return "json";
        if (trimmed.StartsWith('<'))
            return "xml";
        
        throw new NotSupportedException("Unrecognized format.");
    }
}