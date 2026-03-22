using FluentValidation;

namespace Movie_Library.Contracts.Validators;

public class MovieRequestValidator: AbstractValidator<MovieRequest>
{
    public MovieRequestValidator()
    {
        RuleFor(x => x.Rating)
            .NotEmpty()
            .GreaterThan(0)
            .LessThan(10);
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.Author)
            .NotEmpty();
        RuleFor(x => x.Duration)
            .NotEmpty();
        RuleFor(x => x.Genre)
            .NotEmpty();
        RuleFor(x => x.ReleaseDate)
            .NotEmpty();
    }
}