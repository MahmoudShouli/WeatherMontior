using WeatherMonitor.Bots;

namespace WeatherMonitor.config;

public class BotConfig
{
    public required RainBotConfig RainBot { get; set; } 
    public required SunBotConfig SunBot { get; set; }
    public required SnowBotConfig SnowBot { get; set; }
}