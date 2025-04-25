using MovieList.Models;
using System.IO.Pipelines;

namespace MovieList.Data
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> AllMovies { get; }
        IEnumerable<Movie> GetAllMoviesWithGenreDetails();
        IEnumerable<Movie> SpecificMovie { get; }
        Movie GetMovieById(int MovieId);
        public void AddMovie(Movie movie);
        public void DeleteMovie(Movie movie);
        public void EditMovie(Movie movie);
        void SaveChanges();
        IEnumerable<Genre> GetAllGenres();
    }
}
