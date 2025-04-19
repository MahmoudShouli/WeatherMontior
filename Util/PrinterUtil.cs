using System.Text;
using WeatherMonitor.Models;
using WeatherMonitor.Parsers;

namespace WeatherMonitor.Util;

public static class PrinterUtil
{
    public static void PrintMainPrompt(ParserRegistry registry, WeatherContext context, WeatherPublisher publisher)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Enter the weather data or 'Q' to exit :");
            Console.WriteLine("** Press enter two times after your option **");

            var inputBuilder = new StringBuilder();
            string? line;
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                inputBuilder.AppendLine(line);
            }

            var input = inputBuilder.ToString();

            if (input.StartsWith('Q') || input.StartsWith('q') || string.IsNullOrWhiteSpace(input))
                break;
            
            context.SetStrategy(registry.GetParser(HelperUtil.DetectFormat(input))!);
            
            publisher.ChangeWeatherState(context.ReadData(input));
            
            PrintAnyKeyMessage();
            
        }
    }
    
    private static void PrintAnyKeyMessage()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}