using WeatherMonitor.Publisher;

namespace WeatherMonitor.Bots;

public class SunBot : Bot
{
    public double TemperatureThreshold { get; set; }

    public override void Update(IPublisher publisher)
    {
        //
    }
}