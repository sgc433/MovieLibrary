using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Abstractions;

public interface IUserRepository
{
    Task Create(User user);
    Task<User> GetByEmail(string email);
}