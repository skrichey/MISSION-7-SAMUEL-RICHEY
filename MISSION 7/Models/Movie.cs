using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCollection.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; } // Foreign Key

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } // Navigation Property

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, int.MaxValue, ErrorMessage = "Sorry, must add a movie that was released after the year 1888.")]
        public int Year { get; set; }

        public string? Director { get; set; } = null; // Allow NULL values

        public string? Rating { get; set; } = null; // Allow NULL values

        [Required(ErrorMessage = "Edited status is required.")]
        public bool Edited { get; set; }

        public string? LentTo { get; set; } = null;

        [Required(ErrorMessage = "CopiedToPlex status is required.")]
        public bool CopiedToPlex { get; set; }

        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; } = null;
    }
}
