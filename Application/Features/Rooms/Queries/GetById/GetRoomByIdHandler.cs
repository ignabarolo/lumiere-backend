using Domain.Interfaces;
using Lumiere.Application.Exceptions;
using MapsterMapper;
using MediatR;

namespace Application.Features.Rooms.Queries.GetById;

public class GetRoomByIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetRoomByIdQuery, RoomResponse>
{
    public async Task<RoomResponse> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await unitOfWork.RoomRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"Room with ID {request.Id} not found.");

        var roomDto = mapper.Map<RoomResponse>(room);
        return roomDto;
    }
}
