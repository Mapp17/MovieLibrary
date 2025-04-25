using System.ComponentModel.DataAnnotations;

namespace MovieList.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Required]
        public string GenreName { get; set; }

        //Navigation property
        public List<Movie> Movies { get; set; }
    }
}
