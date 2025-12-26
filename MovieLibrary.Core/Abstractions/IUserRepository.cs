using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Abstractions;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User> GetByName(string name);
    Task<User> GetByEmail(string email);
    Task Create(User user);
}