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


        ///////// Add Operations ///////////

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = movieContext.Categories.ToList();
            return View("movieform",new MovieFormResponse()); // We generate a new object so that it has an id already. For sharing the add and edit page
             
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

        //////// Edit Operations ////////
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            // From the db context, from the responses table, get a single record where it matches the id (passed in url)
            var movie = movieContext.Movies
                .Single(x => x.MovieID == id);

            // Renders the MovieForm page, but since we have the asp-for tag helpers, it
            // populates everything for us! It's awesome!!
            return View("MovieForm", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieFormResponse mfr)
        {
            if (ModelState.IsValid)
            {
                movieContext.Update(mfr);
                movieContext.SaveChanges();
                return RedirectToAction("ShowMovies");
            }
            else
            {
                // If it is missing things, it will return the application page with
                // the error messages
                return View("DatingApplication");
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
