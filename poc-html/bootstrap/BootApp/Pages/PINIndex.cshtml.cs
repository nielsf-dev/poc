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
    public class IndexModel2 : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private LinkGenerator linkGenerator;

        public IndexModel2(ILogger<IndexModel> logger, LinkGenerator linkGenerator)
        {
            _logger = logger;
            this.linkGenerator = linkGenerator;
        }

        public IActionResult OnGet()
        {
            var pathByAction = linkGenerator.GetPathByAction("SayHello", "MyRest");
            pathByAction = linkGenerator.GetPathByAction("SayHello2", "MyRest");
          //  pathByAction = linkGenerator.GetPathByAction("SayHello", "MyRes2t");

            // Rare hamvraag weer, waarom word hier Home genegeeerd? Daarom..
            // In TemplateBinder.cs regel 560 word bepaald dat mocht hij hetzelfde zijn als DE default
            // word het niet opgenomen in de url in sommige gevallen

            // Denk dat de verwarring is dat dit echt over MVC links gaat, hij doet echt niks met pages
            var actionLink = Url.ActionLink("Index", "Home");
             actionLink = Url.ActionLink("Shit", "Klote");

            // Maar hier niet?
            actionLink = Url.ActionLink("Index", "DitBoeritDusNiet?");

            actionLink = Url.ActionLink("Onzin", "DitDus");
            actionLink = Url.ActionLink("Index");
            actionLink = Url.ActionLink("Privacy");
            actionLink = Url.ActionLink("Privacy", "Dondersteen");
            actionLink = Url.ActionLink("Privacy", "Home");

            _logger.LogInformation("nu dan");
            return Page();
        }
    }
}
