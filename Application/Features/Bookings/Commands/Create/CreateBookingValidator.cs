using FluentValidation;

namespace Application.Features.Bookings.Commands.Create;

public class CreateBookingValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingValidator()
    {
        RuleFor(x => x.Date)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Date must be in the future or present.");

        RuleFor(x => x.Total)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Total must be greater than zero.");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.");

        RuleFor(x => x.ScreeningId)
            .NotEmpty()
            .WithMessage("ScreeningId is required.");
    }
}
