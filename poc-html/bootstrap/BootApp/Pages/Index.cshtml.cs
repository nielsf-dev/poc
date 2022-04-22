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
        private readonly EndpointDataSource endpointDataSource;

        public IndexModel(ILogger<IndexModel> logger, EndpointDataSource endpointDataSource)
        {
            _logger = logger;
            this.endpointDataSource = endpointDataSource;
        }

        public IActionResult OnGet()
        {
            _logger.LogInformation("nu dan");
            return Page();
        }
    }
}
