using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Abstractions;

public interface IReviewRepository
{
    Task<List<Review>> GetAll();
    Task<Review> GetById(Guid id);
    Task<Guid> Delete(Guid id);
    Task<Guid> Update(Guid id, int rating, string comment);
    Task<Guid> Create(Review review);
}