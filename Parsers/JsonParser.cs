using WeatherMonitor.Models;

namespace WeatherMonitor.Parsers;

public class JsonParser : IParserStrategy
{
    public WeatherState Parse(string input)
    {
        return new WeatherState();
    }
}