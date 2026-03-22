using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Movie_Library.Contracts.Reviews;
using MovieLibrary.Core.Abstractions;
using MovieLibrary.Core.Models;

namespace Movie_Library.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ReviewController(IReviewService reviewService,
    IMovieService movieService, 
    IUserService userService,
    IValidator<ReviewRequest> reviewValidator,
    IValidator<UpdateReviewRequest> updateReviewValidator): ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Review>>> GetAllReviews()
    {
        var  reviews = await reviewService.GetAllReviews();
        var reviewsResponse = reviews
            .Select(r => new ReviewResponse(r.Id, r.Movie, r.User.Username, r.Rating, r.Comment, r.ReviewDate))
            .ToList();
        return Ok(reviewsResponse);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Review>> GetReviewById(Guid id)
    {
        var review = await reviewService.GetReviewById(id);
        var reviewResponse = new ReviewResponse(review.Id,review.Movie,review.User.Username, review.Rating, review.Comment, review.ReviewDate);
        return Ok(reviewResponse);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateReview([FromBody]ReviewRequest request)
    {
        reviewValidator.ValidateAndThrow(request);
        var movie = await  movieService.GetMovieByName(request.MovieName);
        var user = await userService.GetByUserName(request.Username);
        var review = Review.Create(new Guid(), movie, user, request.Rating, request.Comment, request.DateAdded);
        await reviewService.AddReview(review);
        return Ok(review.Id);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteReview(Guid id)
    {
        await reviewService.DeleteReview(id);
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateReview(Guid id, [FromBody] UpdateReviewRequest request)
    {   
        updateReviewValidator.ValidateAndThrow(request);
        await reviewService.UpdateReview(id, request.Rating, request.Comment);
        return Ok(id);
    }
}