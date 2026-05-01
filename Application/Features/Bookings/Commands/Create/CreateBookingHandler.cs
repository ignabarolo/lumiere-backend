using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Bookings.Commands.Create;

public class CreateBookingHandler(IBookingRepository bookingRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateBookingCommand, Guid>
{
    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = mapper.Map<Booking>(request);

        await bookingRepository.AddAsync(booking);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return booking.Id;
    }
}
