using System.Text;

namespace WeatherMonitor.Util;

public static class PrinterUtil
{
    public static string PrintMainPrompt()
    {
        Console.WriteLine("Enter the weather data and press enter two times:");

        var inputBuilder = new StringBuilder();
        string? line;
        while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
        {
            inputBuilder.AppendLine(line);
        }

        return inputBuilder.ToString();
    }
}