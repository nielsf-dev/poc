using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace net5aspcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myBuilder = new MyBuilder();
            myBuilder.DoInterfaceStuff(interf =>
                {
                    interf.AddStuff("stuff");
                })
                .DoOtherStuff();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var defaultBuilder = Host.CreateDefaultBuilder(args);
            return defaultBuilder;
        }
        //    .ConfigureWebHostDefaults(stinkerd());

        private static Action<IWebHostBuilder> stinkerd()
        {
            return webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            };
        }
    }

    public class MyBuilder
    {
        public MyBuilder DoInterfaceStuff(Action<MyInterface> myAction)
        {
            var myImp = new MyImplementation();
            myAction(myImp);
            return this;
        }

        public MyBuilder DoOtherStuff()
        {
            return this;
        }
    }

    public class MyImplementation : MyInterface
    {
        public void AddStuff(string stuff)
        {
            Debug.WriteLine("Doing stuffff!");
        }
    }

    public interface MyInterface
    {
        void AddStuff(string stuff);
    }
}
