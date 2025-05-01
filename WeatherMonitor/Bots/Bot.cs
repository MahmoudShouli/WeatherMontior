using WeatherMonitor.Publisher;

namespace WeatherMonitor.Bots;

public abstract class Bot : ISubscriber
{
    public bool Enabled { get; set; } 
    public bool Activated   { get; set; }
    public string Message { get; set; } = string.Empty;
    
    public abstract void Update(IPublisher publisher);

}