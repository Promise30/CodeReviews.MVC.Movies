using System.ComponentModel.DataAnnotations;

namespace Promise.MVC.Movies.Models
{
    public class EditMovie
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
