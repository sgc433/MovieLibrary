using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MovieLibrary.Core.Models;
using Microsoft.IdentityModel.Tokens;
using MovieLibrary.Core.Abstractions;

namespace MovieLibrary.Infrastructure;

public class JwtProvider(IOptions<JwtOptions> options): IJwtProvider
{
    private readonly JwtOptions _options = options.Value;

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("userId", user.Id.ToString())
        };
        var singingCredentials = new SigningCredentials(
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
        SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            signingCredentials: singingCredentials,
            expires: DateTime.UtcNow.AddHours(_options.ExpiresHours),
            claims: claims
            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}