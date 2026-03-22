using MovieLibrary.Core.Models;

namespace Movie_Library.Contracts.Reviews;

public record ReviewResponse(
    Guid Id,
    Movie Movie,
    string Username,
    int Rating,
    string Comment,
    DateTime ReviewDate);
