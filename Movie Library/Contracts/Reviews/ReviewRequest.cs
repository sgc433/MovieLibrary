using MovieLibrary.Core.Models;

namespace Movie_Library.Contracts.Reviews;

public record ReviewRequest(
    string MovieName,
    string Username,
    int Rating,
    string Comment,
    DateTime DateAdded);