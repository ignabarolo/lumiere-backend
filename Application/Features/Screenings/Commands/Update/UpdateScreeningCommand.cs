using MediatR;

namespace Application.Features.Screenings.Commands.Update;

public record UpdateScreeningCommand(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    Guid MovieId,
    Guid RoomId
) : IRequest<Guid>;
