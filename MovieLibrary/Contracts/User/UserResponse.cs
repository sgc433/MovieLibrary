using System.ComponentModel.DataAnnotations;

namespace Movie_Library.Contracts.User;

public record UserResponse(
    [Required] string Username,
    [Required] string Email,
    [Required] DateTime RegistrationDate);
