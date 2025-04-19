namespace WeatherMonitor.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class FormatAttribute : Attribute
{
    public string Format { get; }
    public FormatAttribute(string format)
    {
        Format = format.ToLower();
    }
}