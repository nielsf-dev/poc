using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using HostBuilding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;


IHostBuilder builder = new MyHostBuilder();
builder.MyCreateDefaults(args);
builder.ConfigureServices(collection =>
{
    collection.AddSingleton<MyHostedServiceCollection>();
});

var host = builder.Build();
host.StartAsync().Wait();

Console.WriteLine("Hello, World!");