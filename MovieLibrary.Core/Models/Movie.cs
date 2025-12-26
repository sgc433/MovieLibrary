using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using MovieLibrary.Core.Enums;
using Serilog;

namespace MovieLibrary.Core.Models;


public class Movie
{
    public const int MAX_TITLE_LENGTH = 100;
    public const int MAX_RATING_VALUE = 10;

    private Movie(Guid id, string title, string description, DateTime releaseDate, string author, GenreEnum genre, TimeSpan duration, decimal rating)
    {
        Id = id;
        Title = title;
        Description = description;
        ReleaseDate = releaseDate;
        Author = author;
        Genre = genre;
        Duration = duration;
        Rating = rating;
    }
    
    public Guid Id { get;  } 
    public string Title { get;  } = string.Empty;
    public string Description { get; } = string.Empty;
    public string Author { get; } = string.Empty;
    public GenreEnum Genre { get;  }
    public List<Review> Reviews { get; } = new();
    public TimeSpan Duration { get;  }
    [MinLength(0)]
    [MaxLength(MAX_TITLE_LENGTH)]
    public decimal Rating { get;  }
    public DateTime ReleaseDate { get; }

    public static Movie Create(
        Guid id, string title, string description, DateTime releaseDate,
        string author, GenreEnum genre, TimeSpan duration, decimal rating)
    {
        

        if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
        {
            Log.Warning("Title can not be empty or longer than {@length} symbols", MAX_TITLE_LENGTH);
        }

        var movie = new Movie(id, title, description, releaseDate, author, genre, duration, rating);
        return movie;
    }
}