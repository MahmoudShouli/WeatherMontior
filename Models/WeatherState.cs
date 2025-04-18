namespace WeatherMonitor.Models;

public class WeatherState
{
    public string Location { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public double Humidity { get; set; }
}