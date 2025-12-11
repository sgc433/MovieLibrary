using MovieLibrary.Core.Abstractions;
using MovieLibrary.Core.Enums;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Services;

public class MovieService: IMovieService
{
    private readonly IMovieRepository _repository;
    public MovieService(IMovieRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Update(Guid id, string title, string description, DateTime releaseDate, string author, GenreEnum genre,
        TimeSpan duration, decimal rating)
    {
        await _repository.Update(id,title, description, releaseDate, author, genre, duration, rating);
        return id;
    }

    public async Task<List<Movie>> GetAllMovies()
    {
        var movies = await _repository.Get();
        return movies;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _repository.Delete(id);
        return id;
    }

    public async Task<Guid> Create(Movie movie)
    {
        await _repository.Create(movie);
        return movie.Id;
    }
}