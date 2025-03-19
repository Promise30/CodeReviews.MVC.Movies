using System.ComponentModel.DataAnnotations;

namespace Promise.MVC.Movies.Models
{
    public class CreateMovie
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        public string? Genre { get; set; }
        [Required]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
