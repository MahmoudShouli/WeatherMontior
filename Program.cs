using WeatherMonitor.Bots;
using WeatherMonitor.config;
using WeatherMonitor.Models;
using WeatherMonitor.Parsers;

namespace WeatherMonitor;

internal static class Program
{
    private static void Main()
    {
        var parser = new XmlParser();
        var context = new WeatherContext(parser);
        var weatherState = context.ReadData("<WeatherData>\n  <Location>City Name</Location>\n  <Temperature>80</Temperature>\n  <Humidity>50.0</Humidity>\n</WeatherData>\n");
        
        var deserializedObject = ConfigUtils.DeserializeConfigFile("./config/BotConfig.json");
        
        ConfigUtils.ConfigBot<SunBot>(out var sunBot, deserializedObject);
        ConfigUtils.ConfigBot<RainBot>(out var rainBot, deserializedObject);
        ConfigUtils.ConfigBot<SnowBot>(out var snowBot, deserializedObject);
        

        var weatherPublisher = new WeatherPublisher();
        weatherPublisher.Attach(snowBot);
        weatherPublisher.Attach(sunBot);
        weatherPublisher.Attach(rainBot);
        
        weatherPublisher.ChangeWeatherState(weatherState);
    }
}