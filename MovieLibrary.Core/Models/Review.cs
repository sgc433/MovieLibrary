namespace MovieLibrary.Core.Models;

public class Review
{
    public Review(Guid id, Movie movie, User user, int rating, string comment, DateTime reviewDate)
    {
        Id = id;
        Movie = movie;
        User = user;
        Rating = rating;
        Comment = comment;
        ReviewDate = reviewDate;
    }
    public Guid Id { get; set; }
    public Movie Movie { get; set; } = null!;
    public User User { get; set; } = null!;
    public int Rating { get; set; } 
    public string Comment { get; set; } = string.Empty;
    public DateTime ReviewDate { get; set; }

    public static Review Create(Guid id, Movie movie, User user, int rating, string comment, DateTime reviewDate)
    {   // validation logic
        var review = new Review(id, movie, user, rating, comment, reviewDate);
        return review;
    }
}