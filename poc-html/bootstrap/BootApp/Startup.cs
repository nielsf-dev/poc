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
                .UseSqlServer("Server=localhost;Database=BootApp;Integrated Security=True")
                .UseLazyLoadingProxies());

            services.AddRazorPages();
            services.AddHostedService<MyService>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger, EndpointDataSource endpointDatasource, BootAppDbContext dbContext)
        {
            logger.LogDebug("Toch in de debug");

            logger.LogInformation("De content root is dus " + env.ContentRootPath);

            dbContext.Database.EnsureCreated();
       
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


            app.Use(async (context, next) =>
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
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            }); 
         

        }
    }
}
