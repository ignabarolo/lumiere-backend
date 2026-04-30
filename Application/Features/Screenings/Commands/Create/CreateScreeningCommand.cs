using MediatR;

namespace Application.Features.Screenings.Commands.Create;

public record CreateScreeningCommand(
    DateTime StartDate,
    DateTime EndDate,
    Guid MovieId,
    Guid RoomId
) : IRequest<Guid>;
