using System.Text;

namespace WeatherMonitor.Util;

public class PrinterUtil
{
    public static string PrintMainPrompt()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Enter the weather and press enter two times or Q to exit");

            var inputBuilder = new StringBuilder();
            string? line;
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                inputBuilder.AppendLine(line);
            }

            return inputBuilder.ToString();

            // if (input.Equals("Q"))
            //     break;
            //
            // PrintAnyKeyMessage();
        }
    }
    
    private static void PrintAnyKeyMessage()
    {
        Console.WriteLine(" Press any key to continue...");
        Console.ReadKey();
    }
}