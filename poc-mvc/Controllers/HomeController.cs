using Microsoft.AspNetCore.Mvc;
using poc_mvc.Models;
using System.Diagnostics;

namespace poc_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index(int id, string vallie)
        {
            Debug.WriteLine(id);
            Debug.WriteLine(vallie);
            return View();
        }

        [Route("/poenanimang/{id=187}/conjomang/{vallie=ietsanders}")]
        public IActionResult Poenani(int id, string vallie)
        {
            Debug.WriteLine(id);
            Debug.WriteLine(vallie);
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}