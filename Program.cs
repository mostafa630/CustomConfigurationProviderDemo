using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ConfigurationProviderDemo.Providers;
using ConfigurationProviderDemo;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddEntityConfiguration();

builder.Services.Configure<NetworkOptions>(
    builder.Configuration.GetSection("NetworkOptions"));

using IHost host = builder.Build();

NetworkOptions options = host.Services.GetRequiredService<IOptions<NetworkOptions>>().Value;
Console.WriteLine($"Name={options.Name}");
Console.WriteLine($"Ip={options.Ip}");
Console.WriteLine($"URL={options.URl}");

await host.RunAsync();
