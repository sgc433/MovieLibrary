using MovieLibrary.Core.Models;

namespace MovieLibrary.DataAccess.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; } 
    public DateTime RegistrationDate { get; set; }
    public string PasswordHash { get; set; }
    public List<ReviewEntity> Reviews { get; set; } = new();
}