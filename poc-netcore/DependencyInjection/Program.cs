using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

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
            //Replace();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(SpecialList);
            serviceCollection.AddSingleton<IBarService, BarService>();
            serviceCollection.AddSingleton<IFooService, FooService>();

            serviceCollection.TryAdd(ServiceDescriptor.Singleton(typeof(IOptions<>), typeof(OptionsManager<>)));
            serviceCollection.TryAdd(ServiceDescriptor.Scoped(typeof(IOptionsSnapshot<>), typeof(OptionsManager<>)));
            serviceCollection.TryAdd(ServiceDescriptor.Singleton(typeof(IOptionsMonitor<>), typeof(OptionsMonitor<>)));
            serviceCollection.TryAdd(ServiceDescriptor.Transient(typeof(IOptionsFactory<>), typeof(OptionsFactory<>)));
            serviceCollection.TryAdd(ServiceDescriptor.Singleton(typeof(IOptionsMonitorCache<>), typeof(OptionsCache<>)));

            //setup our DI
            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            //do the actual work here
            var bar = serviceProvider.GetService<IBarService>();
            var service = serviceProvider.GetService<IOptions<MyOptions>>();
            var serviceValue = service.Value;

            bar.DoSomeRealWork();

            Console.WriteLine("Done!");
        }
        
        public static void Replace()
        {
            Regex regex = new Regex(@"private\sstatic\sILog\slogger\s=\sLogManager\.GetLogger\(typeof\(([^\s]+)\)\);");

            string newLogger = "private static readonly ILogger<{0}> log = LoggerFactory.CreateLogger<{0}>();";

            var dirInfo = new DirectoryInfo(@"C:\Work\visi-backend\core\Service");
            foreach (var fileInfo in dirInfo.EnumerateFiles("*.cs", SearchOption.AllDirectories))
            {
                var streamReader = fileInfo.OpenText();
                var content = streamReader.ReadToEnd();
                streamReader.Dispose();

                var match = regex.Match(content);
                if (match.Success)
                {
                    string className = match.Groups[1].Value;
                    string newLogString = string.Format(newLogger, className);
                    string newContent = content.Replace(match.Value, newLogString);

                    FileStream fileStream = fileInfo.OpenWrite();
                    fileStream.Write(Encoding.UTF8.GetBytes(newContent));
                    fileStream.Dispose();

                    Console.Out.WriteLine(newContent);
                }
            }
        }
    }

    public class MyOptions
    {
        public string Name { get; set; }
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
