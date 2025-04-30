namespace WeatherMonitor.config;

public class SnowBotConfig
{
    public bool Enabled { get; set; }
    public double TemperatureThreshold { get; set; }
    public string Message { get; set; } = string.Empty;
}