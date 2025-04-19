using System.Reflection;
using WeatherMonitor.Attributes;

namespace WeatherMonitor.Parsers;

public class ParserRegistry
{
    private readonly Dictionary<string, IParserStrategy> _parsers = new();

    public ParserRegistry()
    {
        var parserTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(IParserStrategy).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var type in parserTypes)
        {
            var formatAttr = type.GetCustomAttribute<FormatAttribute>();
            if (formatAttr != null)
            {
                var parser = (IParserStrategy)Activator.CreateInstance(type)!;
                _parsers[formatAttr.Format] = parser;
            }
        }
    }

    public IParserStrategy? GetParser(string format) =>
        _parsers.TryGetValue(format.ToLower(), out var parser) ? parser : null;
}
