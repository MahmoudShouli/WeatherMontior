using WeatherMonitor.Bots;
using WeatherMonitor.config;
using WeatherMonitor.Models;

namespace WeatherMonitor;

internal static class Program
{
    private static void Main()
    {
        var weatherState = new WeatherState("New York", 10, 60);
        
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