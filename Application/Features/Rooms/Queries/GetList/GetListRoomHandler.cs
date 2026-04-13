using Application.Features.Movies.Queries.GetList;
using Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Rooms.Queries.GetList;

public class GetListRoomHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetListRoomQuery, List<RoomListResponse>>
{
    public async Task<List<RoomListResponse>> Handle(GetListRoomQuery request, CancellationToken cancellationToken)
    {
        var rooms = await unitOfWork.RoomRepository.GetAllAsync();

        var dto = mapper.Map<List<RoomListResponse>>(rooms);
        return dto;
    }
}
