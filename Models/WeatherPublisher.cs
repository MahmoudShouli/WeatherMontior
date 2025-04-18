using WeatherMonitor.Publisher;

namespace WeatherMonitor.Models;

public class WeatherPublisher : IPublisher
{
    private readonly List<ISubscriber> _subscribers = new List<ISubscriber>();
    public WeatherState WeatherState { get; private set; } = new WeatherState();

    public void Attach(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Detach(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void Notify()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(this);
        }
    }

    public void ChangeWeatherState(WeatherState newState)
    {
        WeatherState = newState;
        Notify();
    }
}