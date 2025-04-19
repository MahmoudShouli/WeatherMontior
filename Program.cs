using WeatherMonitor.Bots;
using WeatherMonitor.config;
using WeatherMonitor.Models;
using WeatherMonitor.Parsers;
using WeatherMonitor.Util;

namespace WeatherMonitor;

internal static class Program
{
    private static void Main()
    {
        //Bots activation and subscription (Subscriber Pattern)
        var deserializedObject = HelperUtil.DeserializeJsonString<BotConfig>("./config/BotConfig.json", true);
        
        ConfigUtils.ConfigBot<SunBot>(out var sunBot, deserializedObject);
        ConfigUtils.ConfigBot<RainBot>(out var rainBot, deserializedObject);
        ConfigUtils.ConfigBot<SnowBot>(out var snowBot, deserializedObject);
        
        var weatherPublisher = new WeatherPublisher();
        weatherPublisher.Attach(snowBot);
        weatherPublisher.Attach(sunBot);
        weatherPublisher.Attach(rainBot);
        
        //Parsers registry and detecting (Strategy Pattern)
        var registry = new ParserRegistry();
        var context = new WeatherContext();
       
        PrinterUtil.PrintMainPrompt(registry, context, weatherPublisher);
    }
}