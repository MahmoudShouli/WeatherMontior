using WeatherMonitor.Publisher;

namespace WeatherMonitor.Bots;

public class RainBot : Bot
{
    public double HumidityThreshold { get; set; }

    public override void Update(IPublisher publisher)
    {
       //
    }
}