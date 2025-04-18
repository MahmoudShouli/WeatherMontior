using WeatherMonitor.Bots;
using WeatherMonitor.Models;

namespace WeatherMonitor;

internal static class Program
{
    private static void Main()
    {
        WeatherState weatherState = new WeatherState("Nablus", 5, 41);

        
        Bot snowBot = new SnowBot(true, 10, "Ooo its getting snowy");
        Bot sunBot = new SunBot(true, 30, "wear your sunglasess!");
        Bot rainBot = new RainBot(false, 40, "dont forget your umbrella!");

        WeatherPublisher weatherPublisher = new WeatherPublisher();
        weatherPublisher.Attach(snowBot);
        weatherPublisher.Attach(sunBot);
        weatherPublisher.Attach(rainBot);
        
        weatherPublisher.ChangeWeatherState(weatherState);
    }
}