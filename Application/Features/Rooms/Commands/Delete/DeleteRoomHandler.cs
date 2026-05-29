using Application.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Rooms.Commands.Delete;

public class DeleteRoomHandler(IRoomRepository roomRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteRoomCommand, Guid>
{
    public async Task<Guid> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"Room with ID {request.Id} not found.");

        roomRepository.Delete(room);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return room.Id;
    }
}
