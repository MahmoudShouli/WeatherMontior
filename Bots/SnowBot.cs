using WeatherMonitor.Models;
using WeatherMonitor.Publisher;

namespace WeatherMonitor.Bots;

public class SnowBot : Bot
{
    public double TemperatureThreshold { get; set; }
    
    public override void Update(IPublisher publisher)
    {
        if (Enabled)
        {
            if ((publisher as WeatherPublisher)!.WeatherState.Temperature < TemperatureThreshold)
            {
                Console.WriteLine("SnowBot activated!");
                Console.WriteLine(Message);
                Console.WriteLine();
            }
        }
    }
}