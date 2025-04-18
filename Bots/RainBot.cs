using WeatherMonitor.Models;
using WeatherMonitor.Publisher;

namespace WeatherMonitor.Bots;

public class RainBot : Bot
{
    private double HumidityThreshold { get; }

    public RainBot(bool isEnabled, double threshold, string message)
        : base(isEnabled, message)
    {
        HumidityThreshold = threshold;
    }
    public override void Update(IPublisher publisher)
    {
        if (IsEnabled)
        {
            if ((publisher as WeatherPublisher)!.WeatherState.Humidity > HumidityThreshold)
            {
                Console.WriteLine("RainBot activated!");
                Console.WriteLine(Message);
                Console.WriteLine();
            } 
        }
    }
}