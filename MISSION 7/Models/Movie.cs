using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, int.MaxValue, ErrorMessage = "Sorry, must add a movie that was released after the year 1888.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Director is required.")]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = "Rating is required.")]
        public string Rating { get; set; } = string.Empty; // G, PG, PG-13, R

        [Required(ErrorMessage = "Edited status is required.")]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "CopiedToPlex status is required.")]
        public bool CopiedToPlex { get; set; }
    }
}
