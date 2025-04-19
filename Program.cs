using WeatherMonitor.Bots;
using WeatherMonitor.Models;
using WeatherMonitor.Parsers;
using WeatherMonitor.Util;

namespace WeatherMonitor;

internal static class Program
{
    private static void Main()
    {
        var data = PrinterUtil.PrintMainPrompt();
        var context = new WeatherContext(new JsonParser());
        var weatherState = context.ReadData(data);
        
        var deserializedObject = ConfigUtils.DeserializeBotsConfigFile("./config/BotConfig.json");
        
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