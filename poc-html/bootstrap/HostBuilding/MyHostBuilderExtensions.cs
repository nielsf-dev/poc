using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

namespace HostBuilding;

public static class MyHostBuilderExtensions
{
    // mijn remake van ConfigureDefaults.. extensions van Microsoft op de IHostBuilder die alle echt basis stuff/configuratie aanmaakt.
    public static IHostBuilder MyCreateDefaults(this IHostBuilder hostBuilder, string[] strings)
    {
        // ipv myHostBuilder.UseContentRoot(Directory.GetCurrentDirectory());
        hostBuilder.ConfigureHostConfiguration(builder =>
        {
            builder.AddInMemoryCollection(new[]
                { new KeyValuePair<string, string>(HostDefaults.ContentRootKey, Directory.GetCurrentDirectory()) });
        });

        hostBuilder.ConfigureHostConfiguration(config =>
        {
            config.AddEnvironmentVariables(prefix: "DOTNET_");
            if (strings is { Length: > 0 })
            {
                config.AddCommandLine(strings);
            }
        });

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode",
            Justification = "Calling IConfiguration.GetValue is safe when the T is bool.")]
        static bool GetReloadConfigOnChangeValue(HostBuilderContext hostingContext) =>
            hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", defaultValue: true);

        hostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
        {
            IHostEnvironment env = hostingContext.HostingEnvironment;
            bool reloadOnChange = GetReloadConfigOnChangeValue(hostingContext);

            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: reloadOnChange)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: reloadOnChange);

            if (env.IsDevelopment() && env.ApplicationName is { Length: > 0 })
            {
                var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                if (appAssembly is not null)
                {
                    config.AddUserSecrets(appAssembly, optional: true, reloadOnChange: reloadOnChange);
                }
            }

            config.AddEnvironmentVariables();

            if (strings is { Length: > 0 })
            {
                config.AddCommandLine(strings);
            }
        })
            .ConfigureLogging((hostingContext, logging) =>
            {
                bool isWindows =
#if NET6_0_OR_GREATER
                OperatingSystem.IsWindows();
#else
                    RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#endif

            // IMPORTANT: This needs to be added *before* configuration is loaded, this lets
            // the defaults be overridden by the configuration.
            if (isWindows)
                {
                // Default the EventLogLoggerProvider to warning or above
                logging.AddFilter<EventLogLoggerProvider>(level => level >= LogLevel.Warning);
                }

                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
#if NET6_0_OR_GREATER
            if (!OperatingSystem.IsBrowser())
#endif
            {
                    logging.AddConsole();
                }

                logging.AddDebug();
                logging.AddEventSourceLogger();

                if (isWindows)
                {
                // Add the EventLogLoggerProvider on windows machines
                logging.AddEventLog();
                }

                logging.Configure(options =>
                {
                    options.ActivityTrackingOptions =
                        ActivityTrackingOptions.SpanId |
                        ActivityTrackingOptions.TraceId |
                        ActivityTrackingOptions.ParentId;
                });
            })
            .UseDefaultServiceProvider((context, options) =>
            {
                bool isDevelopment = context.HostingEnvironment.IsDevelopment();
                options.ValidateScopes = isDevelopment;
                options.ValidateOnBuild = isDevelopment;
            });
        return hostBuilder;

    }
}