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

namespace BootApp
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            using (var ctx = new BootAppDbContext())
            {
                //ctx.Database.EnsureCreated();

                //var persoon = new Person("Nelis", 45);
                //ctx.Add(persoon);
                //ctx.SaveChanges();

                var persons = ctx.Persons.ToList();
                foreach (var person in persons)
                {
                    Debug.WriteLine(person.Name);
                }
            }

            services.AddDbContext<BootAppDbContext>(options => options
                .UseSqlServer("Server=localhost;Database=BootApp;Integrated Security=True")
                .UseLazyLoadingProxies());

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //var persons = bootAppDbContext.Persons.ToList();
            //foreach (var person in persons)
            //{
            //    Debug.WriteLine(person.Name);
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

         //   app.UseDefaultFiles();

         //   app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
