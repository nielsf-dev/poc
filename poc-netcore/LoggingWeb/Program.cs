using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Filters;
using ILogger = Serilog.ILogger;

namespace LoggingWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                    
                    // en dit met die :
                    .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] {RequestPath} {SourceContext} {Message}{NewLine}{Exception}") //[{SourceContext}{Properties:j}]

                    //wasdit
                    .WriteTo.Logger(lc => lc
                        .Filter.ByIncludingOnly(Matching.FromSource("LoggingWeb.Data"))
                        .WriteTo.File("data-log.txt"))
                    .CreateLogger();

            try
            {
                IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);
                hostBuilder.ConfigureWebHostDefaults(webHostBuilder =>
                {
                    webHostBuilder.UseStartup<Startup>()
                        .UseSerilog();
                });

                var host = hostBuilder.Build();
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        //
        // public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        //     .SetBasePath(Directory.GetCurrentDirectory())
        //     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //     .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
        //     .AddEnvironmentVariables()
        //     .Build();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseSerilog();
                });
    }
}
