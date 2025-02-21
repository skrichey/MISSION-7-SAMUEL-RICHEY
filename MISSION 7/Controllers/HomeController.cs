using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            return View("AddMovie", response);
        }

        public IActionResult ViewMovies()
        {
            //Linq query to sort the movies by title
            var movie = _context.Movies
                .OrderBy(x => x.Title).ToList();

            return View(movie);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(movie => movie.MovieId == id);

            return View("AddMovie", recordToEdit);
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
                .Single(movie => movie.MovieId == id);

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


