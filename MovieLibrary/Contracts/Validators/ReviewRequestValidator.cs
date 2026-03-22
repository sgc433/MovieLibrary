using FluentValidation;
using Movie_Library.Contracts.Reviews;

namespace Movie_Library.Contracts.Validators;

public class ReviewRequestValidator: AbstractValidator<ReviewRequest>
{
    public ReviewRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .MaximumLength(50)
            .MaximumLength(3);
        RuleFor(x => x.Comment)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.Rating)
            .NotEmpty()
            .GreaterThan(0)
            .LessThan(10);
        RuleFor(x => x.MovieName)
            .NotEmpty()
            .MaximumLength(100);
    }
}