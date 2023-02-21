using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult ShowMovies()
        {
            var applications = movieContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            ViewBag.Categories = movieContext.Categories.ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = movieContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(MovieFormResponse mfr)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(mfr);
                movieContext.SaveChanges();
                return RedirectToAction("ShowMovies");
                    
            }
            else
            {
                return View(mfr);
            }
            
        }


        ////////// Delete Operations //////////
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = movieContext.Movies.Single(x => x.MovieID == id);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieFormResponse mfr)
        {
            movieContext.Movies.Remove(mfr);
            movieContext.SaveChanges();
            return RedirectToAction("ShowMovies");
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
