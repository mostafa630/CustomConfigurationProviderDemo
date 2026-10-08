using System;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationProviderDemo.Providers;

public class EntityConfigurationContext(string ? connectionString) : DbContext
{
    public DbSet<Settings> Settings => Set<Settings>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = connectionString switch
        {
            { Length: > 0 } => optionsBuilder.UseSqlServer(connectionString),
            _ => optionsBuilder.UseInMemoryDatabase("InMemoryDatabase")
        };
    }
}

