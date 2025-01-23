using Microsoft.AspNetCore.Mvc;

namespace RotetivaReferring.Controllers
{
    public class PDF : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Header()
        {
            return View();
        }

        public IActionResult Footer()
        {
            return View();
        }
    }
}
