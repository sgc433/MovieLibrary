using MovieLibrary.Core.Models;

namespace MovieLibrary.DataAccess.Entities;

public class ReviewEntity
{
    public Guid Id { get; set; }
    public MovieEntity Movie { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
    public int Rating { get; set; } 
    public string Comment { get; set; }
    public DateTime ReviewDate { get; set; }
}