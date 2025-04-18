using WeatherMonitor.Publisher;

namespace WeatherMonitor.Bots;

public abstract class Bot : ISubscriber
{
    protected bool IsEnabled { get; } 
    protected string Message { get; }

    protected Bot(bool isEnabled, string message)
    {
        IsEnabled = isEnabled;
        Message = message;
    }
    public abstract void Update(IPublisher publisher);

}