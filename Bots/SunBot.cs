using WeatherMonitor.Models;
using WeatherMonitor.Publisher;

namespace WeatherMonitor.Bots;

public class SunBot : Bot
{
    private double TemperatureThreshold { get; }

    public SunBot(bool isEnabled, double threshold, string message)
        : base(isEnabled, message)
    {
        TemperatureThreshold = threshold;
    }
    
    public override void Update(IPublisher publisher)
    {
        if (IsEnabled)
        {
            if ((publisher as WeatherPublisher)!.WeatherState.Temperature > TemperatureThreshold)
            {
                Console.WriteLine("SunBot activated!");
                Console.WriteLine(Message);
                Console.WriteLine();
            }
        }
    }
}