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
        
        var deserializedObject = BotConfigUtils.DeserializeBotsConfigFile("./config/BotConfig.json");
        
        BotConfigUtils.ConfigBot<SunBot>(out var sunBot, deserializedObject);
        BotConfigUtils.ConfigBot<RainBot>(out var rainBot, deserializedObject);
        BotConfigUtils.ConfigBot<SnowBot>(out var snowBot, deserializedObject);
        

        var weatherPublisher = new WeatherPublisher();
        weatherPublisher.Attach(snowBot);
        weatherPublisher.Attach(sunBot);
        weatherPublisher.Attach(rainBot);
        
        weatherPublisher.ChangeWeatherState(weatherState);
    }
}