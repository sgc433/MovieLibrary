using MovieLibrary.Core.Enums;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Abstractions;

public interface IMovieRepository
{
    Task<Guid> Create(Movie movie);
    Task<Guid> Delete(Guid id);
    Task<List<Movie>> Get();
    Task<Guid> Update(Guid id, string title, string description, DateTime releaseDate, string author, GenreEnum genre, TimeSpan duration, decimal rating);
}