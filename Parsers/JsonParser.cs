using WeatherMonitor.Attributes;
using WeatherMonitor.config;
using WeatherMonitor.Models;
using WeatherMonitor.Util;

namespace WeatherMonitor.Parsers;

[Format("json")]
public class JsonParser : IParserStrategy
{
    public WeatherState Parse(string input)
    {
        var deserializedObject = HelperUtil.DeserializeJsonString<WeatherStateConfig>(input);
        
        return new WeatherState(deserializedObject.Location, deserializedObject.Temperature, deserializedObject.Humidity);
    }
}