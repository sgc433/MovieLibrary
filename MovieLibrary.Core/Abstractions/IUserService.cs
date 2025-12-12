using Microsoft.AspNetCore.Identity.Data;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Abstractions;

public interface IUserService
{
    Task<User> GetByEmail(string email);
    Task CreateUser(User user);
}