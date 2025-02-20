using Microsoft.EntityFrameworkCore;

namespace MovieCollection.Models
{
    public class MovieCollectionContext : DbContext //Liaison from the app to the database
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options) //Constructor
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
