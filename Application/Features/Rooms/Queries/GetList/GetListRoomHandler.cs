using Application.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Rooms.Queries.GetList;

public class GetListRoomHandler(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<GetListRoomQuery, List<RoomListResponse>>
{
    public async Task<List<RoomListResponse>> Handle(GetListRoomQuery request, CancellationToken cancellationToken)
    {
        var rooms = await roomRepository.GetAllAsync();

        var dto = mapper.Map<List<RoomListResponse>>(rooms);
        return dto;
    }
}
