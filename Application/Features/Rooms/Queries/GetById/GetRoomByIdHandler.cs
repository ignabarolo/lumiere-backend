using Application.Exceptions;
using Application.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Rooms.Queries.GetById;

public class GetRoomByIdHandler(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<GetRoomByIdQuery, RoomResponse>
{
    public async Task<RoomResponse> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"Room with ID {request.Id} not found.");

        var roomDto = mapper.Map<RoomResponse>(room);
        return roomDto;
    }
}
