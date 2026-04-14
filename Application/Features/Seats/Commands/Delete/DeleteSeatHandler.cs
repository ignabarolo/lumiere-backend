using Domain.Interfaces;
using Lumiere.Application.Exceptions;
using MediatR;

namespace Application.Features.Seats.Commands.Delete;

public class DeleteSeatHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteSeatCommand, Guid>
{
    public async Task<Guid> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
    {
        var seat = await unitOfWork.SeatRepository.GetByIdAsync(request.Id)
                        ?? throw new NotFoundException($"Seat with ID {request.Id} not found.");

        unitOfWork.SeatRepository.Delete(seat);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return seat.Id;
    }
}
