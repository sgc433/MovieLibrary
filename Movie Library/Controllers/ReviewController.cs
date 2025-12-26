using Microsoft.AspNetCore.Mvc;
using Movie_Library.Contracts.Reviews;
using MovieLibrary.Core.Abstractions;
using MovieLibrary.Core.Models;

namespace Movie_Library.Controllers;


[ApiController]
[Route("[controller]")]
public class ReviewController: Controller
{
    
    private readonly IReviewService _reviewService;
    private readonly IMovieService _movieService;
    private readonly IUserService _userService;

    public ReviewController(IReviewService reviewService, IMovieService  movieService, IUserService userService)
    {
        _userService = userService;
        _reviewService = reviewService;
        _movieService = movieService;
        
    }

    [HttpGet]
    public async Task<ActionResult<List<Review>>> GetAllReviews()
    {
        var  reviews = await _reviewService.GetAllReviews();
        var reviewsResponse = reviews
            .Select(r => new ReviewResponse(r.Id, r.Movie, r.User.Username, r.Rating, r.Comment, r.ReviewDate))
            .ToList();
        return Ok(reviewsResponse);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Review>> GetReviewById(Guid id)
    {
        var review = await _reviewService.GetReviewById(id);
        var reviewResponse = new ReviewResponse(review.Id,review.Movie,review.User.Username, review.Rating, review.Comment, review.ReviewDate);
        return Ok(reviewResponse);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateReview(ReviewRequest request)
    {
        var movie = await  _movieService.GetMovieByName(request.MovieName);
        var user = await _userService.GetByUserName(request.Username);
        var review = Review.Create(new Guid(), movie, user, request.Rating, request.Comment, request.DateAdded);
        await _reviewService.AddReview(review);
        return Ok(review.Id);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteReview(Guid id)
    {
        await _reviewService.DeleteReview(id);
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateReview(Guid id, string comment, int rating)
    {
        await _reviewService.UpdateReview(id, rating, comment);
        return Ok(id);
    }
}