namespace WeatherMonitor.config;

public class RainBotConfig
{
    public bool Enabled { get; set; }
    public double HumidityThreshold { get; set; }
    public string Message { get; set; } = string.Empty;
}