using WeatherMonitor.Parsers;

namespace WeatherMonitor.Models;

public class WeatherContext
{
    private IParserStrategy _strategy;
    
    public WeatherContext(IParserStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IParserStrategy strategy)
    {
        this._strategy = strategy;
    }

    public WeatherState ReadData(string input)
    {
        return this._strategy.Parse(input);
    }
}