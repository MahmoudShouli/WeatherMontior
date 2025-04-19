using System.Xml.Linq;
using WeatherMonitor.Models;

namespace WeatherMonitor.Parsers;

public class XmlParser : IParserStrategy
{
    public WeatherState Parse(string input)
    {
        var doc = XDocument.Parse(input);
        var root = doc.Element("WeatherData");
    }
}