using MovieLibrary.Core.Enums;

namespace Movie_Library.Contracts;

public record MovieRequest(
    string Title,
    string Description,
    DateTime ReleaseDate,
    string Author,
    GenreEnum Genre,
    TimeSpan Duration,
    decimal Rating);

