using Application.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Seats.Commands.Update;

public class UpdateSeatHandler(ISeatRepository seatRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateSeatCommand, Guid>
{
    public async Task<Guid> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
    {
        var seat = await seatRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"Seat with ID {request.Id} not found.");

        seat.Column = request.Column;
        seat.Row = request.Row;

        seatRepository.Update(seat);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return seat.Id;
    }
}
