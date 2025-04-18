using WeatherMonitor.Publisher;

namespace WeatherMonitor.Bots;

public abstract class Bot : ISubscriber
{
    protected bool IsEnabled { get; set; } = false;
    protected string Message { get; set; } = string.Empty;

    public abstract void Update(IPublisher publisher);

}