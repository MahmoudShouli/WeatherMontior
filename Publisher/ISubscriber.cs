namespace WeatherMonitor.Publisher;

public interface ISubscriber
{
    void Update(IPublisher publisher);
}