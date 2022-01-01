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
                //.UseSqlServer("Server=localhost;Database=BootApp;Integrated Security=True")
                .UseSqlServer("Server=tcp:nielsdbtest-server.database.windows.net,1433;Initial Catalog=BootApp;Persist Security Info=False;User ID=nielsdbtest-server-admin;Password=BakkerSpeesDev187;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
                .UseLazyLoadingProxies());

            services.AddRazorPages();
            services.AddHostedService<MyService>();
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
            
          Func<HttpContext, RequestDelegate, Task> myExecutionNextMiddlewareFunction = async (context, next) =>
          {
              var currentEndpoint = context.GetEndpoint();

              if (currentEndpoint is null)
              {
                  await next(context);
                  return;
              }

              Console.WriteLine($"Endpoint: {currentEndpoint.DisplayName}");

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
                  return myExecutionNextMiddlewareFunction(context, inputDelegate);
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
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
    }
}
