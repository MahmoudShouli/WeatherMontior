using WeatherMonitor.Publisher;

namespace WeatherMonitor.Bots;

public class SnowBot : Bot
{
    public double TemperatureThreshold { get; set; }

    public override void Update(IPublisher publisher)
    {
        //
    }
}