using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promise.MVC.Movies.Data;
using Promise.MVC.Movies.Models;
using Promise.MVC.Movies.Services;
using System.Text.Json;

namespace Promise.MVC.Movies.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _dbContext;
        private readonly IDatabaseLogger _logger;

        public MoviesController(MovieDbContext dbContext, IDatabaseLogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(string searchString)
        {
            try
            {
                var movies = _dbContext.Movies.AsQueryable();

                if (!string.IsNullOrEmpty(searchString))
                {

                     movies = movies.Where(x =>
                         EF.Functions.Like(x.Title, $"%{searchString}%") ||
                        EF.Functions.Like(x.Director, $"%{searchString}%"));
                }
                movies = movies.OrderBy(x => x.Title);

                var viewModel = new MovieViewModel { Movies = movies.ToList() };

                ViewBag.SearchString = searchString;

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);

                var emptyViewModel = new MovieViewModel();
                TempData["ErrorMessage"] = "An error occurred while retrieving movies. Please try again.";

                return View(emptyViewModel);
            }
        }

        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateMovie(CreateMovie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            try
            {
                var movieToCreate = new Movie
                {
                    Title = movie.Title,
                    Director = movie.Director,
                    Genre = movie.Genre,
                    Price = movie.Price,
                    ReleaseDate = movie.ReleaseDate
                };
                _dbContext.Movies.Add(movieToCreate);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                ModelState.AddModelError("", "An error occurred while creating the movie. Please try again.");
                return View(movie);
            }
        }

        [HttpGet]
        public IActionResult MovieDetail(int id)
        {
            try
            {
                var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);
                if (movie == null)
                {
                    return NotFound();
                }
                return View(movie);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return View("Error", new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
            }
        }

        //[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);
                if (movie == null)
                {
                    return NotFound();
                }
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                TempData["Error"] = "An error occurred while deleting the movie.";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            try
            {
                var movie = _dbContext.Movies.Find(id);
                if (movie == null)
                {
                    return NotFound();
                }
                
                return View(movie);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return View("Error", new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult EditMovie(int id, EditMovie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            try
            {
                var movieToEdit = _dbContext.Movies.FirstOrDefault(m => m.Id == id);
                if (movieToEdit == null)
                {
                    return NotFound();
                }
                
                movieToEdit.Title = movie.Title;
                movieToEdit.Director = movie.Director;
                movieToEdit.Genre = movie.Genre;
                movieToEdit.Price = movie.Price;
                movieToEdit.ReleaseDate = movie.ReleaseDate;
                
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                ModelState.AddModelError("", "An error occurred while updating the movie. Please try again.");
                return View(movie);
            }
        }
    }
}
