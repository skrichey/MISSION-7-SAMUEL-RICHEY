using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCollection.Models;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private MovieCollectionContext _context;
        public HomeController(MovieCollectionContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View();
        }


        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);

        }

        public IActionResult ViewMovies()
        {
            // Fetch movies and include category information
            var movies = _context.Movies
                .Include(m => m.Category) // Ensures we pull the category name
                .OrderBy(m => m.Title)
                .ToList();

            return View(movies);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Include(m => m.Category) // Ensure we fetch the category info
                .SingleOrDefault(movie => movie.MovieId == id);

            if (recordToEdit == null)
            {
                return NotFound(); // Handle case where movie does not exist
            }

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", recordToEdit); // Reuse AddMovie view for editing
        }


        [HttpPost]
        public IActionResult Edit(Movie updatedResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(updatedResponse);
                _context.SaveChanges();
                return RedirectToAction("ViewMovies");
            }
            return View("AddMovie", updatedResponse);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Include(m => m.Category) // Ensures category info is available
                .SingleOrDefault(movie => movie.MovieId == id);

            if (recordToDelete == null)
            {
                return NotFound(); // Handle case where movie does not exist
            }

            return View("Delete", recordToDelete);
        }


        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("ViewMovies");
        }
    }
}


