using MovieLibrary.Core.Enums;

namespace MovieLibrary.Contracts;

public record MovieResponse(
    Guid Id,
    string Title,
    string Description,
    DateTime ReleaseDate,
    string Author,
    GenreEnum Genre,
    TimeSpan Duration,
    decimal Rating);
