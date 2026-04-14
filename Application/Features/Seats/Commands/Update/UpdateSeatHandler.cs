using Domain.Interfaces;
using Lumiere.Application.Exceptions;
using MediatR;

namespace Application.Features.Seats.Commands.Update;

public class UpdateSeatHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateSeatCommand, Guid>
{
    public async Task<Guid> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
    {
        var seat = await unitOfWork.SeatRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"Seat with ID {request.Id} not found.");

        seat.Column = request.Column;
        seat.Row = request.Row;

        unitOfWork.SeatRepository.Update(seat);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return seat.Id;
    }
}
