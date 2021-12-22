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
    collection.AddHostedService<MyHostedService>();
});

var host = builder.Build();

// vraag van de dag, wat is het verschil tussen deze 2
// kennelijk blokt alleen d
// \
// ie laatste wat JIJ dus niet verwacht van deze shit....
host.StartAsync().Wait();
host.RunAsync().GetAwaiter().GetResult();


Console.WriteLine("Hello, World!");