using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace BootApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private LinkGenerator linkGenerator;

        public IndexModel(ILogger<IndexModel> logger, LinkGenerator linkGenerator)
        {
            _logger = logger;
            this.linkGenerator = linkGenerator;
        }

        public IActionResult OnGet()
        {
            var pathByAction = linkGenerator.GetPathByAction("SayHello", "MyRest");

            _logger.LogInformation("nu dan");
            return Page();
        }
    }
}
