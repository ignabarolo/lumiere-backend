using Application.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Rooms.Commands.Update;

public class UpdateRoomHandler(IRoomRepository roomRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateRoomCommand, Guid>
{
    public async Task<Guid> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The room {request.Id} was not found");

        room.Room_Number = request.Room_Number;
        room.Capacity = request.Capacity;

        roomRepository.Update(room);
        await unitOfWork.SaveChangesAsync();

        return room.Id;
    }
}
