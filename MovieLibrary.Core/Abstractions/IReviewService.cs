using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Abstractions;

public interface IReviewService
{
    Task<List<Review>> GetAllReviews();
    Task<Review> GetReviewById(Guid id);
    Task<Guid> AddReview(Review review);
    Task<Guid> UpdateReview(Guid id, int rating, string comment);
    Task<Guid> DeleteReview(Guid id);
}