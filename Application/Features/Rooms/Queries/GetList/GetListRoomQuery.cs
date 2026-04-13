using MediatR;

namespace Application.Features.Rooms.Queries.GetList;

public record GetListRoomQuery() : IRequest<List<RoomListResponse>>;
