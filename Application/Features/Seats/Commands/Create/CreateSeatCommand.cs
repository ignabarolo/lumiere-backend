using MediatR;

namespace Application.Features.Seats.Commands.Create;

public record CreateSeatCommand(string Row, int Column, Guid RoomId) : IRequest<Guid>;
