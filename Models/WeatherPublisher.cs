using WeatherMonitor.Publisher;

namespace WeatherMonitor.Models;

public class WeatherPublisher : IPublisher
{
    private readonly List<ISubscriber> _subscribers = new List<ISubscriber>();
    private WeatherState _weatherState = new WeatherState();

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
        _weatherState = newState;
        Notify();
    }
}