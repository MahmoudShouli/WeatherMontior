using WeatherMonitor.Models;
using WeatherMonitor.Publisher;

namespace WeatherMonitor.Bots;

public class RainBot : Bot
{
    public double HumidityThreshold { get; set; }
    
    public override void Update(IPublisher publisher)
    {
        if (Enabled)
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