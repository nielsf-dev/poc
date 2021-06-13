using Microsoft.Extensions.Logging;

namespace EntityFramework.MyModel
{
    public class LoggerFactory
    {
        private static ILoggerFactory loggerFactory;

        public static ILogger<T> CreateLogger<T>()
        {
            return loggerFactory.CreateLogger<T>();
        }

        public static ILoggerFactory Instance
        {
            get => loggerFactory;
            set => loggerFactory = value;
        }
    }
}