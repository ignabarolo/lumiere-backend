using FluentValidation;

namespace Application.Features.Cinemas.Commands.Update;

public class UpdateCinemaCommandValidator : AbstractValidator<UpdateCinemaCommand>
{
    public UpdateCinemaCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().NotEmpty().WithMessage("The ID is required.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("The address is required.")
            .MaximumLength(100).WithMessage("The address must not exceed 100 characters.");
    }
}