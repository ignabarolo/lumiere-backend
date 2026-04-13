using MediatR;

namespace Application.Features.Rooms.Queries.GetById;

public record GetRoomByIdQuery(Guid Id) : IRequest<RoomResponse>;
