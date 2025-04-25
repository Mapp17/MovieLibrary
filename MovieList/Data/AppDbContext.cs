using Microsoft.EntityFrameworkCore;
using MovieList.Models;


namespace MovieList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, GenreName = "Action" },
                new Genre { GenreId = 2, GenreName = "Comedy" },
                new Genre { GenreId = 3, GenreName = "Drama" },
                new Genre { GenreId = 4, GenreName = "Horror" },
                new Genre { GenreId = 5, GenreName = "Musical" },
                new Genre { GenreId = 6, GenreName = "RomCom" },
                new Genre { GenreId = 7, GenreName = "SciFi" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Name = "Slumdog Millionaire",
                    Year = 2008,
                    Rating = 3,
                    GenreId = 3
                },
                new Movie
                {
                    MovieId = 2,
                    Name = "Pearl Harbor",
                    Year = 2001,
                    Rating = 4,
                    GenreId = 3
                },
                new Movie
                {
                    MovieId = 3,
                    Name = "Titanic",
                    Year = 1997,
                    Rating = 5,
                    GenreId = 3
                }
            );
        }


    }
}
