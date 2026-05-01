using Application.Exceptions;
using Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Bookings.Queries.GetById;

public class GetBookingByIdHandler(IBookingRepository bookingRepository, IMapper mapper) : IRequestHandler<GetBookingByIdQuery, BookingResponse>
{
    public async Task<BookingResponse> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var booking = await bookingRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The booking {request.Id} was not found");

        var bookingDto = mapper.Map<BookingResponse>(booking);

        return bookingDto;
    }
}
