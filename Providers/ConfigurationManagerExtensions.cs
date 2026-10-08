using Microsoft.Extensions.Configuration;

namespace ConfigurationProviderDemo.Providers;

public static class ConfigurationManagerExtensions
{
    public static ConfigurationManager AddEntityConfiguration(
           this ConfigurationManager manager)
    {
        
        // so the connection string length will be 0 so it will use the In_Memory database.
        var connectionString = "";
      

        IConfigurationBuilder configBuilder = manager;
        configBuilder.Add(new EntityConfigurationSource(connectionString));

        return manager;
    }
}
