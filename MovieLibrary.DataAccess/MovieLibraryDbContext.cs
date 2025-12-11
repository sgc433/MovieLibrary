using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Models;
using MovieLibrary.DataAccess.Entities;

namespace MovieLibrary.DataAccess;

public class MovieLibraryDbContext: DbContext
{
    public MovieLibraryDbContext(DbContextOptions<MovieLibraryDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<MovieEntity> Movies { get; set; }
}