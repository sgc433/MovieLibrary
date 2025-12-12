using MovieLibrary.Core.Abstractions;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Services;

public class AuthService(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider)
    : IAuthService
{
    public async Task Register(string username, string email, string password)
    {
        var hashedPassword = passwordHasher.Generate(password);
        var user = User.Create(Guid.NewGuid(), username, hashedPassword,email, DateTime.UtcNow);
        await userRepository.Create(user);
    }

    public async Task<string> Login(string email, string password)
    {
        var user = await userRepository.GetByEmail(email);
        var result = passwordHasher.Verify(password, user.PasswordHash);
        if (result == false)
        {
            throw new Exception("Password doesn't match");
        }

        var token = jwtProvider.GenerateToken(user);
        return token;
    }
}