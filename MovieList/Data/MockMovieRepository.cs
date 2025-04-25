using MovieList.Models;

namespace MovieList.Data
{
    public class MockMovieRepository 
    {
        public IEnumerable<Movie> AllMovies => new List<Movie>
        {   new Movie {Name = "Pearl Harbor", Year = 2001, GenreId = 1, Rating =4},
            new Movie {Name = "Slumdog Millionaire", Year = 2008, GenreId = 2, Rating =3},
            new Movie {Name = "Titanic", Year = 1, GenreId = 1, Rating = 5},
            };



        public IEnumerable<Movie> SpecificMovie { get; }

        public void AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void EditMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int MovieId)
        {
            return AllMovies.FirstOrDefault(m => m.MovieId == MovieId);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
