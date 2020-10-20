using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggingWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using Serilog;

namespace LoggingWeb
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> logger;
        private TestRepository testRepository;

        public TestController(ILogger<TestController> logger, TestRepository testRepository)
        {
            this.logger = logger;
            this.testRepository = testRepository;
        }

        [HttpGet]
        [Route("/")]
        public string Test()
        {
            logger.LogInformation("GO Johny GO");
            Log.Information("SERIGO Johny GO");

            logger.LogTrace("Dit komt niet, of toch wel");
            Log.Verbose("Dit komtSERILOGGG YEAH niet, of toch wel");

            List<string> data = testRepository.GetData();

            Log.CloseAndFlush();
            return $"Testing {data.Count}";
        }
    }
}
