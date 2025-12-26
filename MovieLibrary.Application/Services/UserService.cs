using MovieLibrary.Core.Abstractions;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Services;

public class UserService(IUserRepository userRepository)
    : IUserService
{
    public async Task<User> GetByEmail(string email)
    {
        var user = await userRepository.GetByEmail(email);
        return user;
    }

    public async Task<User> GetByUserName(string userName)
    {
        var user = await userRepository.GetByName(userName);
        return user;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var users = await userRepository.GetAll();
        return users;
    }

    public async Task CreateUser(User user)
    {
        await userRepository.Create(user);
    }
    
}

