using FluentValidation;

namespace Application.Features.Screenings.Commands.Update;

public class UpdateScreeningValidator : AbstractValidator<UpdateScreeningCommand>
{
    public UpdateScreeningValidator()
    {
        RuleFor(s => s.StartDate)
            .NotEmpty()
            .LessThan(s => s.EndDate)
            .WithMessage("Start date must be before end date.");

        RuleFor(s => s.EndDate)
            .NotEmpty()
            .GreaterThan(s => s.StartDate)
            .WithMessage("End date must be after start date.");
        RuleFor(s => s.RoomId)
           .NotEmpty()
           .WithMessage("Room ID is required.");

        RuleFor(s => s.MovieId)
            .NotEmpty()
            .WithMessage("Movie ID is required.");
    }
}
