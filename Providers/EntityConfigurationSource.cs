using System;
using Microsoft.Extensions.Configuration;

namespace ConfigurationProviderDemo.Providers;

public class EntityConfigurationSource(string? connectionString) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder)
        =>new EntityConfigurationProvider(connectionString);
    
}
