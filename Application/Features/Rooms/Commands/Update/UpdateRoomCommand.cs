using MediatR;

namespace Application.Features.Rooms.Commands.Update;

public record UpdateRoomCommand(Guid Id, int Room_Number, int Capacity) : IRequest<Guid>;
