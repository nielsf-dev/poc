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
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogDebug("Toch in de debug");

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
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
