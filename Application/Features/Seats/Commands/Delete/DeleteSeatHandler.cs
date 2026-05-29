using Application.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Seats.Commands.Delete;

public class DeleteSeatHandler(ISeatRepository seatRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteSeatCommand, Guid>
{
    public async Task<Guid> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
    {
        var seat = await seatRepository.GetByIdAsync(request.Id)
                        ?? throw new NotFoundException($"Seat with ID {request.Id} not found.");

        seatRepository.Delete(seat);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return seat.Id;
    }
}
