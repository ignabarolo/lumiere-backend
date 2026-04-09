using FluentValidation;

namespace Application.Features.Cinemas.Commands.Create;

public class CreateCinemaCommandValidator : AbstractValidator<CreateCinemaCommand>
{
    public CreateCinemaCommandValidator()
    {
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("The address is required.")
            .MaximumLength(100).WithMessage("The address must not exceed 100 characters.");

        RuleFor(x => x.Rooms).NotEmpty().WithMessage("The Cinema must have at least one room.");
    }
}
