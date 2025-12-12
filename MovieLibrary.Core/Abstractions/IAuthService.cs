namespace MovieLibrary.Core.Abstractions;

public interface IAuthService
{
    Task Register(string username, string email, string password);
    Task<string> Login(string email, string password);
}