using FluentValidation;

namespace Application.Features.Movies.Commands.Create;

public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("The title is required.")
            .MaximumLength(100).WithMessage("The title must not exceed 100 characters.");

        RuleFor(x => x.Genre)
            .NotEmpty().WithMessage("The genre is required.")
            .MaximumLength(50).WithMessage("The genre must not exceed 50 characters.");

        RuleFor(x => x.DurationMinutes)
            .GreaterThan(0).WithMessage("The duration must be greater than 0.");

        RuleFor(x => x.Classification)
            .NotEmpty().WithMessage("The classification is required.")
            .MaximumLength(20).WithMessage("The classification must not exceed 20 characters.");
    }
}
