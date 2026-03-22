using System.ComponentModel.DataAnnotations;

namespace Movie_Library.Contracts.User;

public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);