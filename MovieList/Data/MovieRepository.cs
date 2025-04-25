using Microsoft.EntityFrameworkCore;
using MovieList.Models;

namespace MovieList.Data
{
    public class MovieRepository : IMovieRepository
    {
        public readonly AppDbContext _appDbContext;
        public MovieRepository (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Movie> AllMovies
        {
            get
            {
                return _appDbContext.Movies;
            }
        }

        public IEnumerable<Movie> SpecificMovie
        {
            get
            {
                return (IEnumerable<Movie>)_appDbContext.Movies.Select(m => m.Name);
            }
        }

        public void AddMovie(Movie movie)
        {
            _appDbContext.Movies.Add(movie);
        }

        public Movie GetMovieById(int MovieId)
        {
            return _appDbContext.Movies.FirstOrDefault(m => m.MovieId == MovieId);
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }

        public void DeleteMovie(Movie movie)
        {
            _appDbContext.Movies.Remove(movie);
        }

        public void EditMovie(Movie movie)
        {
            _appDbContext.Movies.Update(movie);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _appDbContext.Genres;
        }

        public IEnumerable<Movie> GetAllMoviesWithGenreDetails()
        {
            return _appDbContext.Movies.Include(m => m.Genre);
        }
    }
}
