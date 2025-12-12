using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Abstractions;

public interface IJwtProvider
{
    string GenerateToken(User user);
}