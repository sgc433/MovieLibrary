using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Abstractions;
using MovieLibrary.Core.Enums;
using MovieLibrary.Core.Models;
using MovieLibrary.DataAccess.Entities;

namespace MovieLibrary.DataAccess.Repositories;

public class MovieRepository: IMovieRepository
{
    private readonly MovieLibraryDbContext _context;
    public MovieRepository(MovieLibraryDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Create(Movie movie)
    {
        var movieEntity = new MovieEntity()
        {
            Id = movie.Id,
            Title = movie.Title,
            Author = movie.Author,
            Description = movie.Description,
            Duration = movie.Duration,
            Genre = movie.Genre,
            Rating = movie.Rating,
            ReleaseDate = movie.ReleaseDate
        };
        await _context.AddAsync(movieEntity);
        await _context.SaveChangesAsync();

        return movieEntity.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Movies
            .Where(m => m.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }

    public async Task<List<Movie>> Get()
    {
        var movieEntities = await _context.Movies
            .AsNoTracking()
            .ToListAsync();
        var movies = movieEntities
            .Select(m => Movie.Create(m.Id,m.Title,m.Description,m.ReleaseDate,m.Author,m.Genre,m.Duration,m.Rating))
            .ToList();
        return movies;
    }
    

    public async Task<Guid> Update(Guid id, string title, string description, DateTime releaseDate, string author, GenreEnum genre,
        TimeSpan duration, decimal rating)
    {
        await _context.Movies
            .Where(m => m.Id == id)
            .ExecuteUpdateAsync<MovieEntity>(s => s
                .SetProperty(m => m.Title, title)
                .SetProperty(m => m.Author, author)
                .SetProperty(m => m.Description,  description)
                .SetProperty(m => m.Genre, genre)
                .SetProperty(m => m.Duration, duration)
                .SetProperty(m => m.Rating, rating)
                .SetProperty(m => m.ReleaseDate, releaseDate));
        return id;
        
    }

    public async Task<Movie> GetByName(string name)
    {
        var movieEntity = await _context.Movies
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Title == name);
        if (movieEntity is null)
        {
            throw new Exception($"Movie with name {name} not found");
        }
        var movie = Movie.Create(
            movieEntity.Id,
            movieEntity.Title,
            movieEntity.Description,
            movieEntity.ReleaseDate,
            movieEntity.Author,
            movieEntity.Genre,
            movieEntity.Duration,
            movieEntity.Rating);
        return movie;
    }
}