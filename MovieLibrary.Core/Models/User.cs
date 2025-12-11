namespace MovieLibrary.Core.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    /*public List<WatchHistory> WatchedMovies { get; set; }
    public List<UserPreference> Preferences { get; set; }*/
}