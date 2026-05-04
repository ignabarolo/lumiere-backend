using FluentValidation;

namespace Application.Features.Rooms.Commands.Update;

public class UpdateRoomValidator : AbstractValidator<UpdateRoomCommand>
{
    public UpdateRoomValidator()
    {
        RuleFor(x => x.RoomNumber)
            .GreaterThan(0).WithMessage("The room number must be greater than 0.");

        RuleFor(x => x.Capacity)
            .GreaterThan(0).WithMessage("The capacity must be greater than 0.");
    }
}
