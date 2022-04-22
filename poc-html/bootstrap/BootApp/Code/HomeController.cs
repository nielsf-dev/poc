using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BsVisi.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

    //    [HttpGet("home/index")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // [HttpGet]
        // [Route("/hetzal")]
        public IActionResult HetZal()
        {
            return RedirectToPage("/ModelStateFault");
        }
        public IActionResult ZonderController()
        {
            return View();
        }

        public string IkReturnEenString()
        {
            return "Dit dus";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return View();
        }
    }
}