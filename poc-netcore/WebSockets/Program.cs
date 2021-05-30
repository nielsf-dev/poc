using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WebSocketExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                // en dit met die :
                .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {RequestPath} {Message}{Exception} @ {SourceContext:20}{NewLine}") //[{SourceContext}{Properties:j}]

                //wasdit
                .WriteTo.Logger(lc => lc
                    // .Filter.ByIncludingOnly(Matching.FromSource("LoggingWeb.Data"))
                    .WriteTo.File("c:\\work\\websockets-log.txt"))
                .CreateLogger();

            Log.Information("Logger aangemaakt");

            var webHostBuilder = CreateWebHostBuilder(args);
            var build = webHostBuilder.Build();
            build.Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .UseSerilog()
                .ConfigureWebHostDefaults(builder =>
                    {
                        builder.UseStartup<Startup>();
                        builder.UseUrls("http://localhost:1877");
                    }
                );
    }
}