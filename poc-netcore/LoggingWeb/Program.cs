using System;
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
using Serilog.Extensions.Logging;
using Serilog.Filters;
using ILogger = Serilog.ILogger;

namespace LoggingWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()

                    .Enrich.With(new SimpleClassEnricher())

                    // en dit met die :
                    .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {RequestPath} {Message}{Exception} @ {SourceContext:20}{NewLine}") //[{SourceContext}{Properties:j}]

                    //wasdit
                    .WriteTo.Logger(lc => lc
                        .Filter.ByIncludingOnly(Matching.FromSource("LoggingWeb.Data"))
                        .WriteTo.File("data-log.txt"))
                    .CreateLogger();

            Log.Information("Whutever");

            SerilogLoggerFactory factory = new SerilogLoggerFactory(Log.Logger);
            ILogger<Program> logger = factory.CreateLogger<Program>();
            logger.LogInformation("Zo kan het dus ook");

            try
            {
                var host = CreateHostBuilder(args).Build();
                Log.Information("Host aangemaakt");
                host.Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return;
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

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            IHostBuilder defaultBuilder = Host.CreateDefaultBuilder(args);
            return defaultBuilder.ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseSerilog();
                });
        }
    }
}
