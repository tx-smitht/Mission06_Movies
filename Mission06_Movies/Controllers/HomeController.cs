using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_Movies.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieEntryContext movieContext { get; set; }
        public HomeController(ILogger<HomeController> logger, MovieEntryContext context)
        {
            _logger = logger;
            movieContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(MovieFormResponse mfr)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(mfr);
                movieContext.SaveChanges();
                return View("ConfirmationPage", mfr);
                    
            }
            else
            {
                return View(mfr);
            }
            
        }

        public IActionResult Podcasts()
        {
            return View();
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
