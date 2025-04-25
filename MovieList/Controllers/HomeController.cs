using Microsoft.AspNetCore.Mvc;
using MovieList.Data;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        public HomeController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_movieRepository.GetAllMoviesWithGenreDetails().OrderBy(m=>m.Name));
        }

    }
}
