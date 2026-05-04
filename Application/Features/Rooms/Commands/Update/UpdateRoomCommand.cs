using MediatR;

namespace Application.Features.Rooms.Commands.Update;

public record UpdateRoomCommand(Guid Id, int RoomNumber, int Capacity) : IRequest<Guid>;
