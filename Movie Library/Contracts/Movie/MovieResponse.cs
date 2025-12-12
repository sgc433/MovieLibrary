using MovieLibrary.Core.Enums;

namespace Movie_Library.Contracts;

public record MovieResponse(
    Guid Id,
    string Title,
    string Description,
    DateTime ReleaseDate,
    string Author,
    GenreEnum Genre,
    TimeSpan Duration,
    decimal Rating);
