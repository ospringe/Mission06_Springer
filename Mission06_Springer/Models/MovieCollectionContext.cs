using Microsoft.EntityFrameworkCore;

namespace Mission06_Springer.Models;

// Used to interact with the Movie Collection SQLite database
public class MovieCollectionContext : DbContext
{
    // As we create a MovieCollectionContext instance, is we're giving a way in the constructor here to set up any options and include the base options in that setup.
    public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options) // Constructor that sets up those options
    {
        
    }
    
    public DbSet<Movie> Movies { get; set; } // Creating a database set of type 'Movie' that we are going to refer to as 'Movies.' (When we create the database, the table is going to be called 'Movies'?)
    public DbSet<Category> Categories { get; set; }
}