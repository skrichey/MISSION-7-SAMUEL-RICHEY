using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Movie>? Movies { get; set; }
    }
}
