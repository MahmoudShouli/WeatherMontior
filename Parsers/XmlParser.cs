using System.Xml.Linq;
using WeatherMonitor.Attributes;
using WeatherMonitor.Models;

namespace WeatherMonitor.Parsers;

[Format("xml")]
public class XmlParser : IParserStrategy
{
    public WeatherState Parse(string input)
    {
        var doc = XDocument.Parse(input);
        var root = doc.Element("WeatherData");

        if (root == null)
        {
            throw new FormatException("Invalid weather data");
        }
        
        var location = root.Element("Location")?.Value ?? string.Empty;
        var temperature = double.Parse(root.Element("Temperature")?.Value ?? "0");
        var humidity = double.Parse(root.Element("Humidity")?.Value ?? "0");

        return new WeatherState(location, temperature, humidity);
    }
}