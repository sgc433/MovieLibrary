using FluentValidation;
using Movie_Library.Contracts.Reviews;

namespace Movie_Library.Contracts.Validators;

public class UpdateReviewRequestValidator: AbstractValidator<UpdateReviewRequest>
{
    public UpdateReviewRequestValidator()
    {
        RuleFor(x => x.Comment)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.Rating)
            .NotEmpty()
            .GreaterThan(0)
            .LessThan(10);
    }    
}
