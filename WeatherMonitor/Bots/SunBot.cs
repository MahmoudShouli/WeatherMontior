using WeatherMonitor.Models;
using WeatherMonitor.Publisher;

namespace WeatherMonitor.Bots;

public class SunBot : Bot
{
    public double TemperatureThreshold { get; set; }
    
    public override void Update(IPublisher publisher)
    {
        if (Enabled)
        {
            if ((publisher as WeatherPublisher)!.WeatherState.Temperature > TemperatureThreshold)
            {
                Activated = true;
                Console.WriteLine("SunBot activated!");
                Console.WriteLine(Message);
                Console.WriteLine();
            }
        }
    }
}