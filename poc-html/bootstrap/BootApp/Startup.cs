using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BootApp.Code;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;

namespace BootApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BootAppDbContext>(options => options
                .UseSqlServer("Server=localhost;Database=BootApp;Integrated Security=True")
                //.UseSqlServer("Server=tcp:nielsdbtest-server.database.windows.net,1433;Initial Catalog=BootApp;Persist Security Info=False;User ID=nielsdbtest-server-admin;Password=BakkerSpeesDev187;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
                .UseLazyLoadingProxies());

            services.AddRazorPages();
            //  services.AddHostedService<MyService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogDebug("Toch in de debug");

            logger.LogInformation("De content root is dus " + env.ContentRootPath);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            //   app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            Func<HttpContext, RequestDelegate, Task> myExecuteNextMiddlewareFunction = async (context, next) =>
            {
                var currentEndpoint = context.GetEndpoint();

                if (currentEndpoint is null)
                {
                    await next(context);
                    return;
                }

                Console.WriteLine($"Endpoint: {currentEndpoint.DisplayName}");

                //context.Response.BodyWriter.WriteAsync()
                var attribute = currentEndpoint?.Metadata.OfType<MyAttribute>();
                if (attribute.ToArray().Length > 0)
                {
                    // werkt dus out-of-the-box dit, kan hem op de method zelf zetten of op class niveau
                    Console.WriteLine("got it");
                }

                if (currentEndpoint is RouteEndpoint routeEndpoint)
                {
                    Console.WriteLine($"  - Route Pattern: {routeEndpoint.RoutePattern.RawText}");
                }

                foreach (var endpointMetadata in currentEndpoint.Metadata)
                {
                    Console.WriteLine($"  - Metadata: {endpointMetadata}");
                }

                await next(context);

            };

            // Dit gaat dus niet omdat input delegate niet beschikbaar is
            // RequestDelegate myWrapper = context =>
            // {
            //     myExecutionNextMiddlewareFunction(context, inputDelegate);
            // };

            Func<RequestDelegate, RequestDelegate> myLinkerFunction = inputDelegate =>
            {
                //input delegate komt hier uit, de "next" in onze middleware function, en deze is dus yet to be decided
                RequestDelegate outputDelegate = context =>
                  {
                      return myExecuteNextMiddlewareFunction(context, inputDelegate);
                  };

                // wat voert de delegate uit die gereturned word?
                // F#1 onze middleware function, met als input de yet to be decided

                return outputDelegate;
            };

            app.Use(myLinkerFunction);

            // stel dit is de laatste, dan voert de applicationbuilder deze uit met als input een "throw error" request delegate.

            // de vorige middleware, krijgt dan als next F#1

            returnInt n = i => 5 * i;
            var result = n(10);

            app.UseMiddleware<MyExecutionMiddleware>();

            object routeBuilder;
            app.Properties.TryGetValue("__EndpointRouteBuilder", out routeBuilder);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/tyfus", () => "sdfg").RequireAuthorization();

                var controllerActionEndpointConventionBuilder = endpoints.MapControllers();

                // zo kan dus metadata worden toegevoegd aan endpoints? JAZEKER!
                controllerActionEndpointConventionBuilder.Add(builder =>
                {
                    builder.Metadata.Add(new Person("metadata", 23));
                });

                var pageActionEndpointConventionBuilder = endpoints.MapRazorPages();
                pageActionEndpointConventionBuilder.Add(builder =>
                {
                    if (builder.DisplayName == "/Index")
                    {
                        builder.Metadata.Add(new Person("gaaf hoor werkt", 23));
                    }
                });
            });



            var endpointRouteBuilder = routeBuilder as IEndpointRouteBuilder;
            var dataSource = endpointRouteBuilder.DataSources.GetEnumerator().Current;

            // blijkt dat in de datasources die door de Map functies worden aangemaakt, zitten de endpoints al in, inclusief requestdelegates
        }

        public delegate int returnInt(int n);

        private RequestDelegate myRequestFunction(RequestDelegate input)
        {
            return context =>
            {
                Console.WriteLine(context.Connection);
                return Task.CompletedTask;
            };
        }

        private class MyEndpointRouteBuilder : IEndpointRouteBuilder
        {
            public IApplicationBuilder CreateApplicationBuilder()
            {
                throw new NotImplementedException();
            }

            public IServiceProvider ServiceProvider { get; }
            public ICollection<EndpointDataSource> DataSources { get; }
        }

        private class MyEndpointDataSource : EndpointDataSource
        {
            public override IChangeToken GetChangeToken()
            {
                throw new NotImplementedException();
            }

            public override IReadOnlyList<Endpoint> Endpoints { get; }
        }
    }
}
