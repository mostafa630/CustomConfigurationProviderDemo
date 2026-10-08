using Microsoft.Extensions.Configuration;

namespace ConfigurationProviderDemo.Providers;

public sealed class EntityConfigurationProvider(string? connectionString) : ConfigurationProvider
{
    public override void Load()
    {
        using var dbContext = new EntityConfigurationContext(connectionString);
        dbContext.Database.EnsureCreated();

        Data = dbContext.Settings.Any()
            ? dbContext.Settings.ToDictionary(
                static c => c.Id,
                static c => c.Value, StringComparer.OrdinalIgnoreCase)
            : CreateAndSaveDefaultValues(dbContext);
    }
    static Dictionary<string, string?> CreateAndSaveDefaultValues(
        EntityConfigurationContext context)
    {
        var settings = new Dictionary<string, string?>(
            StringComparer.OrdinalIgnoreCase)
        {
            ["NetworkOptions:Name"] = "google.com",
            ["NetworkOptions:Ip"] = "8.8.8.8",
            ["NetworkOptions:URL"] = "api/test"
        };

        context.Settings.AddRange(
            [.. settings.Select(static kvp => new Settings(kvp.Key, kvp.Value))]);

        context.SaveChanges();

        return settings;
    }
}
