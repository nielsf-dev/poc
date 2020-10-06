using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    class Program
    {
        public static List<string> SpecialList
        {
            get
            {
                return new List<string>()
                {
                    "BAKKER",
                    "SPEES"
                };
            }
        }

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(SpecialList);
            serviceCollection.AddSingleton<IBarService, BarService>();
            serviceCollection.AddSingleton<IFooService, FooService>();

            //setup our DI
            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            //do the actual work here
            var bar = serviceProvider.GetService<IBarService>();
            bar.DoSomeRealWork();

            Console.WriteLine("Done!");
        }
    }

    public interface IFooService
    {
        void DoNumber(int number);
    }

    public interface IBarService
    {
        void DoSomeRealWork();
    }

    public class BarService : IBarService
    {
        private readonly IFooService _fooService;
        public BarService(IFooService fooService)
        {
            _fooService = fooService;
        }

        public void DoSomeRealWork()
        {
            for (int i = 0; i < 10; i++)
            {
                _fooService.DoNumber(i);
            }
        }
    }

    public class FooService : IFooService
    {
        private List<string> specialStrings;

        public FooService(List<string> specialStrings)
        {
            this.specialStrings = specialStrings;
        }

        public void DoNumber(int number)
        {
            Console.WriteLine($"Doing {number}");
        }
    }


}
