using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using NLog.Web;
using Serilog;
using Serilog.Filters;

namespace LoggingWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Properties:j} {Message:lj}{NewLine}{Exception}")
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(Matching.FromSource("LoggingWeb.Data"))
                    .WriteTo.File("data-log.txt"))
                .CreateLogger();

            Log.Information("Hello, Serilog!");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 // .ConfigureLogging(logging =>
                 //    {
                 //        logging.ClearProviders();
                 //        logging.AddConsole(LogLevel.Trace);
                 //    })

                   //.UseNLog()  // NLog: Setup NLog for Dependency injection

                   .ConfigureWebHostDefaults(webBuilder =>
                   {
                       webBuilder.UseStartup<Startup>();
                   });
    }
}
