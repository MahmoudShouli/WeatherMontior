using WeatherMonitor.Models;

namespace WeatherMonitor.Parsers;

public interface IParserStrategy
{
    WeatherState Parse(string input);
}