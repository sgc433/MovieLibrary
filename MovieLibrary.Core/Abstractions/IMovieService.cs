using MovieLibrary.Core.Enums;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Abstractions;

public interface IMovieService
{
    Task<Guid> Update(Guid id, string title, string description, DateTime releaseDate, string author, GenreEnum genre, TimeSpan duration, decimal rating);
    Task<List<Movie>> GetAllMovies();
    Task<Guid> Delete(Guid id);
    Task<Guid> Create(Movie movie);
    Task<Movie> GetMovieByName(string name);
}