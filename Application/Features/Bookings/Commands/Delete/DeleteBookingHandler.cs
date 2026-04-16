using Domain.Interfaces;
using Lumiere.Application.Exceptions;
using MediatR;

namespace Application.Features.Bookings.Commands.Delete;

public class DeleteBookingHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteBookingCommand, Guid>
{
    public async Task<Guid> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await unitOfWork.BookingRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The booking {request.Id} was not found");

        unitOfWork.BookingRepository.Delete(booking);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return booking.Id;
    }
}
