using FluentValidation;

namespace Application.Features.Seats.Commands.Create;

public class CreateSeatValidator : AbstractValidator<CreateSeatCommand>
{
    public CreateSeatValidator()
    {
        RuleFor(x => x.Row)
            .NotEmpty().WithMessage("Row is required.")
            .MaximumLength(5).WithMessage("Row cannot exceed 5 characters.");

        RuleFor(x => x.Column)
            .GreaterThan(0).WithMessage("Column must be greater than 0.");

        RuleFor(x => x.RoomId)
            .NotNull().NotEmpty().WithMessage("RoomId is required.");
    }
}
