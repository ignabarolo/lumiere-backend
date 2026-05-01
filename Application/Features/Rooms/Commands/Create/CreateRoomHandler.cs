using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Rooms.Commands.Create;

public class CreateRoomHandler(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateRoomCommand, Guid>
{
    public async Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = mapper.Map<Room>(request);

        await roomRepository.AddAsync(room);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return room.Id;
    }
}
