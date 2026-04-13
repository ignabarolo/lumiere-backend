using MediatR;

namespace Application.Features.Rooms.Commands.Delete;

public record DeleteRoomCommand(Guid Id) : IRequest<Guid>;
