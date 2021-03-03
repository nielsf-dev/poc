using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostBuilder
{
    class Program
    {
        public static void Main(string[] args)
        {
            //noIHostedServiceAdded();
            startWeb();

            //IHostBuilder hostedWorker = simpleHostedWorker(args);
            //IHost host = hostedWorker.Build();
            //host.Run();
        }

        private static void startWeb()
        {
            IHostBuilder defaultBuilder = Host.CreateDefaultBuilder();
            defaultBuilder.ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<MyStartup>();
            });

            // ConfigureWebHostDefaults is dus niet een echte hostbuilder methode surprise surprise
            // maar een extension voor:
            /*
             *    var webhostBuilder = new GenericWebHostBuilder(builder);
                  configure(webhostBuilder); // hier word alle user configuratie aangeroepen, hierboven dus UseStartup

                  builder.ConfigureServices((context, services) => services.AddHostedService<GenericWebHostService>());
                  return builder;
             */

            IHost host = defaultBuilder.Build();
            host.Run();

            // uiteindelijk word hier ook die internal host aangeroepen, die een asp.net IHostedService start 

        }
        public class MyStartup
        {
            public void ConfigureServices(IServiceCollection services)
            {
            }

            public void Configure(IApplicationBuilder app)
            {
                app.UseDefaultFiles();
                app.UseStaticFiles();
                app.UseFileServer(enableDirectoryBrowsing: true);
                app.UseWebSockets(); // Only for Kestrel
            }
        }

        private static void noIHostedServiceAdded()
        {
            IHostBuilder hostBuilder = new Microsoft.Extensions.Hosting.HostBuilder();

            // Vage interface, de implementatie(HostBuilder) roept al die configure stuff aan

            //hostBuilder.ConfigureAppConfiguration((context, builder) =>
            //{
            //    Console.WriteLine("yolo");
            //});

            //hostBuilder.ConfigureHostConfiguration();
            //hostBuilder.ConfigureContainer()
            //hostBuilder.ConfigureServices()

            // Op deze manieer in Build()
            /*
             *     BuildHostConfiguration();
                   CreateHostingEnvironment();
                   CreateHostBuilderContext();
                   BuildAppConfiguration();

                    // Hier word de hosting environment + Host toegevoegd aan de services              }
                 CreateServiceProvider();
            /*
             
            public interface IHostingEnvironment
              {
                /// <summary>
                /// Gets or sets the name of the application. This property is automatically set by the host to the assembly containing
                /// the application entry point.
                /// </summary>
                string ApplicationName { get; set; }

                /// <summary>
                /// Gets or sets an <see cref="T:Microsoft.Extensions.FileProviders.IFileProvider" /> pointing at <see cref="P:Microsoft.Extensions.Hosting.IHostingEnvironment.ContentRootPath" />.
                /// </summary>
                IFileProvider ContentRootFileProvider { get; set; }

                /// <summary>
                /// Gets or sets the absolute path to the directory that contains the application content files.
                /// </summary>
                string ContentRootPath { get; set; }

                /// <summary>
                /// Gets or sets the name of the environment. The host automatically sets this property to the value of the
                /// of the "environment" key as specified in configuration.
                /// </summary>
                string EnvironmentName { get; set; }
             */

            IHost host = hostBuilder.Build();

            //neeueuuhhh. dus die Run() zit niet eens in de IHost
            // Het zit in de HostingAbstractionsHostExtensions (dus)
            /*
                public static void Run(this IHost host)
                {
                    host.RunAsync().GetAwaiter().GetResult();
                }
             */

            // de default host is dus Microsoft.Extensions.Hosting.Internal.Host
            // je heb 2 Host.cs dus meh die andere is Microsoft.Extenstion.Hosting.Host DUS

            // enfin wat het doet is 
            /*
             *  _hostedServices = Services.GetService<IEnumerable<IHostedService>>();

                foreach (var hostedService in _hostedServices)
                {
                    // Fire IHostedService.Start
                    await hostedService.StartAsync(combinedCancellationToken).ConfigureAwait(false);
                }
             */

            host.Run();

            // en dat zijn er normaal gesproken op deze manier dus geen (hosted services)
        }

        public static IHostBuilder simpleHostedWorker(string[] args)
        {
            var defaultBuilder = Host.CreateDefaultBuilder(args);
            defaultBuilder = defaultBuilder.ConfigureServices((hostContext, services) => { services.AddHostedService<Worker>(); });
            return defaultBuilder;
        }
    }

    class MyWebBuilder : IWebHostBuilder
    {
        public IWebHost Build()
        {
            throw new NotImplementedException();
        }

        public IWebHostBuilder ConfigureAppConfiguration(Action<WebHostBuilderContext, IConfigurationBuilder> configureDelegate)
        {
            throw new NotImplementedException();
        }

        public IWebHostBuilder ConfigureServices(Action<WebHostBuilderContext, IServiceCollection> configureServices)
        {
            throw new NotImplementedException();
        }

        public IWebHostBuilder ConfigureServices(Action<IServiceCollection> configureServices)
        {
            throw new NotImplementedException();
        }

        public string GetSetting(string key)
        {
            throw new NotImplementedException();
        }

        public IWebHostBuilder UseSetting(string key, string value)
        {
            throw new NotImplementedException();
        }
    }


    class MyBuilder : IHostBuilder
    {
        public IHostBuilder ConfigureHostConfiguration(Action<IConfigurationBuilder> configureDelegate)
        {
            throw new NotImplementedException();
        }

        public IHostBuilder ConfigureAppConfiguration(Action<HostBuilderContext, IConfigurationBuilder> configureDelegate)
        {
            throw new NotImplementedException();
        }

        public IHostBuilder ConfigureServices(Action<HostBuilderContext, IServiceCollection> configureDelegate)
        {
            throw new NotImplementedException();
        }

        public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory)
        {
            throw new NotImplementedException();
        }

        public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(Func<HostBuilderContext, IServiceProviderFactory<TContainerBuilder>> factory)
        {
            throw new NotImplementedException();
        }

        public IHostBuilder ConfigureContainer<TContainerBuilder>(Action<HostBuilderContext, TContainerBuilder> configureDelegate)
        {
            throw new NotImplementedException();
        }

        public IHost Build()
        {
            throw new NotImplementedException();
        }

        public IDictionary<object, object> Properties { get; }
    }

    class MyHost : IHost
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        // hier zit dus gewoon alles in van logging tot configuratie tot de hostedservices
        public IServiceProvider Services { get; }
    }

    class Worker : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _appLifetime;

        public Worker(
            ILogger<Worker> logger,
            IHostApplicationLifetime appLifetime)
        {
            _logger = logger;
            _appLifetime = appLifetime;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(OnStarted);
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _appLifetime.ApplicationStopped.Register(OnStopped);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _logger.LogInformation("OnStarted has been called.");

            // Perform post-startup activities here
        }

        private void OnStopping()
        {
            _logger.LogInformation("OnStopping has been called.");

            // Perform on-stopping activities here
        }

        private void OnStopped()
        {
            _logger.LogInformation("OnStopped has been called.");

            // Perform post-stopped activities here
        }
    }
}
