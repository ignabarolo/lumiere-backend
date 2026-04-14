using FluentValidation;

namespace Application.Features.Seats.Commands.Update;

public class UpdateSeatValidator : AbstractValidator<UpdateSeatCommand>
{
    public UpdateSeatValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().NotEmpty().WithMessage("The ID is required.");
        
        RuleFor(x => x.Row)
            .NotEmpty().WithMessage("The row is required.")
            .MaximumLength(1).WithMessage("The row must not exceed 1 character.");

        RuleFor(x => x.Column)
            .GreaterThan(0).WithMessage("The column must be greater than 0.");
    }
}
