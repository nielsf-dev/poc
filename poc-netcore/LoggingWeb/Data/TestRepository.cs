using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LoggingWeb.Data
{
    public class TestRepository
    {
        private ILogger<TestRepository> logger;

        public TestRepository(ILogger<TestRepository> logger)
        {
            this.logger = logger;
        }

        public List<string> GetData()
        {
            logger.LogInformation("Getting data");
          //  Log.Information("Getting SERIdata");

            var data = new List<string>()
            {
                "One",
                "Two",
                "Three"
            };
            logger.LogTrace($"Returning {data.Count} strings");
        //    Log.Verbose($"Returning serserer{data.Count} strings");

            return data;
        }
    }
}