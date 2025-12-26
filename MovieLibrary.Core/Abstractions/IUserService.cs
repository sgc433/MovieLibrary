using Microsoft.AspNetCore.Identity.Data;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Abstractions;

public interface IUserService
{
    Task<User> GetByEmail(string email);
    Task<User> GetByUserName(string userName);
    Task<List<User>> GetAllUsers();
    Task CreateUser(User user);
}