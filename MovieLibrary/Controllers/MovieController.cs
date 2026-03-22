using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Movie_Library.Contracts;
using Movie_Library.Contracts.Validators;
using MovieLibrary.Contracts;
using MovieLibrary.Core.Abstractions;
using MovieLibrary.Core.Models;

namespace Movie_Library.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController(IMovieService movieService,
    IValidator<MovieRequest> movieValidator) : Controller
{
    [HttpGet]
    public async Task<ActionResult<List<Movie>>> GetMovies()
    {
        var movies = await movieService.GetAllMovies();
        var response = movies.Select(m => new MovieResponse(m.Id,m.Title,m.Description,m.ReleaseDate,m.Author,m.Genre,m.Duration,m.Rating));
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateMovie([FromBody] MovieRequest request)
    {
        movieValidator.ValidateAndThrow(request);
        var movie = Movie.Create(
            new Guid(),
            request.Title,
            request.Description,
            request.ReleaseDate,
            request.Author,
            request.Genre,
            request.Duration,
            request.Rating
        );
        var movieId = await movieService.Create(movie);
        return Ok(movieId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateMovie(Guid id, [FromBody] MovieRequest request)
    {
        movieValidator.ValidateAndThrow(request);
        var movieId = await movieService.Update(
            id,
            request.Title,
            request.Description,
            request.ReleaseDate,
            request.Author,
            request.Genre,
            request.Duration,
            request.Rating
            );
        return Ok(movieId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteMovie(Guid id)
    {
        await movieService.Delete(id);
        return Ok(id);
    }
}