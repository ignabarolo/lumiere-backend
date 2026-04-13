using Domain.Interfaces;
using Lumiere.Application.Exceptions;
using MediatR;

namespace Application.Features.Rooms.Commands.Delete;

public class DeleteRoomHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteRoomCommand, Guid>
{
    public async Task<Guid> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await unitOfWork.RoomRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"Room with ID {request.Id} not found.");

        unitOfWork.RoomRepository.Delete(room);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return room.Id;
    }
}
