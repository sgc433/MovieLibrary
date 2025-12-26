using MovieLibrary.Core.Abstractions;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Services;

public class ReviewService(IReviewRepository reviewRepository) : IReviewService
{
    private readonly IReviewRepository _reviewRepository = reviewRepository;

    public async Task<List<Review>> GetAllReviews()
    {
        var reviews = await _reviewRepository.GetAll();
        return reviews;
    }

    public async Task<Review> GetReviewById(Guid id)
    {
        var review = await _reviewRepository.GetById(id);
        return review;
    }

    public async Task<Guid> AddReview(Review review)
    {
        await _reviewRepository.Create(review);
        return review.Id;
    }

    public async Task<Guid> UpdateReview(Guid id, int rating, string comment)
    {
        await _reviewRepository.Update(id, rating, comment);
        return id;
    }

    public async Task<Guid> DeleteReview(Guid id)
    {
        await _reviewRepository.Delete(id);
        return id;
    }
}