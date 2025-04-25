using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieList.Data;
using MovieList.Models;

namespace MovieList.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        [HttpGet]
        public IActionResult Add()
        {
            PopulateGenreDLL();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.AddMovie(movie);
                _movieRepository.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                PopulateGenreDLL();
                return View(movie);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null)
                return NotFound();
            else
            {
                return View(movie);
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteStudent(Movie movie)
        {
            if (movie != null)
            {
                _movieRepository.DeleteMovie(movie);
                _movieRepository.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Unable to Delete student";
                
            }
            return View(movie);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null)
                return NotFound();
            else
            {
                PopulateGenreDLL(movie.GenreId);
                return View(movie);
            }
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _movieRepository.EditMovie(movie);
                    _movieRepository.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            PopulateGenreDLL(movie.GenreId);
            return View(movie);
        }

        private void PopulateGenreDLL(object selectedGenre = null)
        {
            ViewBag.Genres = new SelectList(_movieRepository.GetAllGenres()
                .OrderBy(g => g.GenreName),
                "GenreId", "GenreName", selectedGenre);
        }
        
    }
}
