using System.ComponentModel.DataAnnotations;

namespace Movie_Library.Contracts.User;

public record RegisterUserRequest(
    [Required] string Username,
    [Required] string Password,
    [Required] string Email);
