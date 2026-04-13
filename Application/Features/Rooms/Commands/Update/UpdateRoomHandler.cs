using Domain.Entities;
using Domain.Interfaces;
using Lumiere.Application.Exceptions;
using MediatR;

namespace Application.Features.Rooms.Commands.Update;

public class UpdateRoomHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateRoomCommand, Guid>
{
    public async Task<Guid> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await unitOfWork.RoomRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The room {request.Id} was not found");

        room.Room_Number = request.Room_Number;
        room.Capacity = request.Capacity;

        unitOfWork.RoomRepository.Update(room);
        await unitOfWork.SaveChangesAsync();

        return room.Id;
    }
}
