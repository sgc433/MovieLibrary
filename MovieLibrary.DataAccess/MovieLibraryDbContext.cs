using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Models;
using MovieLibrary.DataAccess.Entities;

namespace MovieLibrary.DataAccess;

public class MovieLibraryDbContext(DbContextOptions<MovieLibraryDbContext> options) : DbContext(options)
{
    public DbSet<MovieEntity> Movies { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }
}