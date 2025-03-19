using Microsoft.AspNetCore.Mvc;
using Promise.MVC.Movies.Data;
using Promise.MVC.Movies.Models;
using System.Text.Json;

namespace Promise.MVC.Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _dbContext;

        public MoviesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index(string searchString)
        {
            var movies = _dbContext.Movies.ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(x => x.Title.Contains(searchString)).ToList();
            }
            var viewModel = new MovieViewModel { Movies = movies };
            return View(viewModel);
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
            if(!ModelState.IsValid)
            {
                return View(movie);
            }
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
        [HttpGet]
        public IActionResult MovieDetail(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(x=> x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        public IActionResult DeleteMovie(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(x=> x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            
            return View(movie);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult EditMovie(int id, EditMovie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
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
    }
}
