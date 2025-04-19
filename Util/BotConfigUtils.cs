using System.Text.Json;
using System.Reflection;
using WeatherMonitor.Bots;
using WeatherMonitor.config;

namespace WeatherMonitor.Util;

public static class BotConfigUtils
{
    public static BotConfig DeserializeBotsConfigFile(string path)
    {
        var jsonString = File.ReadAllText(path);
        return HelperUtil.DeserializeJsonString<BotConfig>(jsonString);
    }
    
    public static void ConfigBot<T>(out T bot, BotConfig config) where T : Bot, new()
    {
        bot = new T();

        var botTypeName = typeof(T).Name; 
        
        PropertyInfo? configProp = typeof(BotConfig).GetProperty(botTypeName);
        if (configProp == null)
            throw new InvalidOperationException($"No config section found for bot type '{botTypeName}'");

        
        object? configInstance = configProp.GetValue(config);
        if (configInstance == null)
            throw new InvalidOperationException($"Config for '{botTypeName}' is null");
        
        foreach (var configProperty in configInstance.GetType().GetProperties())
        {
            PropertyInfo? botProperty = typeof(T).GetProperty(configProperty.Name);
            if (botProperty != null && botProperty.CanWrite)
            {
                object? value = configProperty.GetValue(configInstance);
                if (value != null)
                    botProperty.SetValue(bot, value);
            }
        }
    }
}