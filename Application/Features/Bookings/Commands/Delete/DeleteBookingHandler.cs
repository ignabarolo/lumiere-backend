using Application.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Bookings.Commands.Delete;

public class DeleteBookingHandler(IBookingRepository bookingRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteBookingCommand, Guid>
{
    public async Task<Guid> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await bookingRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The booking {request.Id} was not found");

        bookingRepository.Delete(booking);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return booking.Id;
    }
}
