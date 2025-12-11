using MovieLibrary.Core.Enums;

namespace MovieLibrary.DataAccess.Entities;

public class MovieEntity
{
    public Guid Id { get; set; } 
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public GenreEnum Genre { get; set; }
    public TimeSpan Duration { get; set; }
    public decimal Rating { get; set; }
    public DateTime ReleaseDate { get; set; }
}