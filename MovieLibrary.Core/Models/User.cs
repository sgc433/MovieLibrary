namespace MovieLibrary.Core.Models;

public class User
{
    private User(Guid id, string username, string passwordHash, string email, DateTime registrationDate)
    {
        Id = id;
        Username = username;
        PasswordHash = passwordHash;
        Email = email;
        RegistrationDate = registrationDate;
    }

    public List<Review> Reviews { get; set; } = new();
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; } 
    public DateTime RegistrationDate { get; private set; }
    public string PasswordHash { get; private set; }

    public static User Create(Guid id, string username, string passwordHash, string email, DateTime registrationDate)
    {
        return new User(id, username, passwordHash, email, registrationDate);
    }
    /*public List<WatchHistory> WatchedMovies { get; set; }
    public List<UserPreference> Preferences { get; set; }*/
}