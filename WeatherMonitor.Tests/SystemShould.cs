using WeatherMonitor.Bots;
using WeatherMonitor.Models;
using Xunit;

namespace WeatherMonitor.Tests;


public class SystemShould
{

    [Fact]
    public void ActivateRainBot_OnRainyDay()
    {
        // Arrange
        var rainBot = new RainBot() { HumidityThreshold = 30, Enabled = true };
        var weatherPublisher = new WeatherPublisher();
        var weatherState = new WeatherState() { Humidity = 31 };

        // Act
        weatherPublisher.Attach(rainBot);
        weatherPublisher.ChangeWeatherState(weatherState);

        // Assert
        Assert.True(rainBot.Activated);
    }
    
    [Fact]
    public void ActivateSunBot_OnSunnyDay()
    {
        // Arrange
        var sunBot = new SunBot() { TemperatureThreshold = 30, Enabled = true };
        var weatherPublisher = new WeatherPublisher();
        var weatherState = new WeatherState() { Temperature = 31 };

        // Act
        weatherPublisher.Attach(sunBot);
        weatherPublisher.ChangeWeatherState(weatherState);

        // Assert
        Assert.True(sunBot.Activated);
    }
    
    [Fact]
    public void ActivateSnowBot_OnSnowyDay()
    {
        // Arrange
        var snowBot = new SnowBot() { TemperatureThreshold = 5, Enabled = true };
        var weatherPublisher = new WeatherPublisher();
        var weatherState = new WeatherState() { Temperature = 3 };

        // Act
        weatherPublisher.Attach(snowBot);
        weatherPublisher.ChangeWeatherState(weatherState);

        // Assert
        Assert.True(snowBot.Activated);
    }
}