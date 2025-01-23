using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using RotetivaReferring.Models;

namespace RotetivaReferring.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            PersonViewModel person = new PersonViewModel();
            person.name = "Hiren";
            person.age = 19;
            return View(person);
        }


        public IActionResult GeneratePdf()
        {
            PersonViewModel person = new PersonViewModel();
            person.name = "Hiren";
            person.age = 19;

            // Explain Inside Url.Action things below
            //Controller, View, parameter to our action method for data dynamic show in Header and footer

            var headerUrl = Url.Action("Header", "PDF", null, Request.Scheme);
            var footerUrl = Url.Action("Footer", "PDF", null, Request.Scheme);


            // Create the custom switches for wkhtmltopdf
            string customSwitches = string.Format(
            "--header-spacing 10 --header-html \"{0}\" --footer-spacing 2 --footer-html \"{1}\" ",
            headerUrl, footerUrl);


            // Return a PDF generated from a view
            return new ViewAsPdf("Index", person) // The view name ("Index") is the page content for the PDF
            {
                FileName = "example.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = new Rotativa.AspNetCore.Options.Margins(30, 10, 30, 10),
                CustomSwitches = customSwitches
            };
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
