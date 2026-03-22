using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Abstractions;
using MovieLibrary.Core.Models;
using MovieLibrary.DataAccess.Entities;

namespace MovieLibrary.DataAccess.Repositories;

public class ReviewRepository(MovieLibraryDbContext context): IReviewRepository
{
    private readonly MovieLibraryDbContext _context = context;


    public async Task<List<Review>> GetAll()
    {
        var reviewsEntity = await _context.Reviews
            .Include(r => r.User)
            .Include(r => r.Movie)
            .AsNoTracking()
            .ToListAsync();

        var reviews = reviewsEntity
            .Select(r => Review.Create(
                r.Id,
                Movie.Create(
                    r.Movie.Id,
                    r.Movie.Title,
                    r.Movie.Description,
                    r.Movie.ReleaseDate,
                    r.Movie.Author,
                    r.Movie.Genre,
                    r.Movie.Duration,
                    r.Movie.Rating),
                User.Create(
                    r.User.Id,
                    r.User.Username,
                    r.User.PasswordHash,
                    r.User.Email,
                    r.User.RegistrationDate),
                r.Rating,
                r.Comment,
                r.ReviewDate))
            .ToList();
        return reviews;
        
    }

    public async Task<Review> GetById(Guid id)
    {
        var reviewEntity = await _context.Reviews
            .Include(r => r.User)
            .Include(r => r.Movie)
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);

        
        if (reviewEntity != null)
        {
            var user = User.Create(
                reviewEntity.User.Id,
                reviewEntity.User.Username,
                reviewEntity.User.PasswordHash,
                reviewEntity.User.Email,
                reviewEntity.User.RegistrationDate
            );

            var movie = Movie.Create(
                reviewEntity.Movie.Id,
                reviewEntity.Movie.Title,
                reviewEntity.Movie.Description,
                reviewEntity.Movie.ReleaseDate,
                reviewEntity.Movie.Author,
                reviewEntity.Movie.Genre,
                reviewEntity.Movie.Duration,
                reviewEntity.Movie.Rating
                );
            
            var review = Review.Create(reviewEntity.Id, movie, user, reviewEntity.Rating,
                reviewEntity.Comment, reviewEntity.ReviewDate);
            return review;
        }
        throw new Exception();
    }

    public async Task<Guid> Delete(Guid id)
    {
        var review = await _context.Reviews
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }

    public async Task<Guid> Update(Guid id,int rating, string comment)
    {
        var review = await _context.Reviews
            .Where(r => r.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(r => r.Rating , rating)
                .SetProperty(r => r.Comment, comment)
            );
        return id;
    }

    public async Task<Guid> Create(Review review)
    {
        
        var movie = await  _context.Movies.FirstOrDefaultAsync(m => m.Id == review.Movie.Id);
        if (movie is null)
            throw new Exception();
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == review.User.Username);
        if (user is null)
            throw new Exception();
        var reviewEntity = new ReviewEntity
        {
            Id = review.Id,
            Rating = review.Rating,
            Comment = review.Comment,
            ReviewDate = review.ReviewDate,
            Movie = movie,
            User = user
        };
        await _context.Reviews.AddAsync(reviewEntity);
        await _context.SaveChangesAsync();
        return reviewEntity.Id;
    }
}