using Domain.Interfaces;
using Application.Exceptions;
using MapsterMapper;
using MediatR;

namespace Application.Features.Bookings.Queries.GetById;

public class GetBookingByIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetBookingByIdQuery, BookingResponse>
{
    public async Task<BookingResponse> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var booking = await unitOfWork.BookingRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The booking {request.Id} was not found");

        var bookingDto = mapper.Map<BookingResponse>(booking);

        return bookingDto;
    }
}
