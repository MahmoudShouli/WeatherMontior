namespace WeatherMonitor.config;

public class WeatherStateConfig
{
    public string Location { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public double Humidity { get; set; }
}