using Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Bookings.Queries.GetList;

public class GetListBookingHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetListBookingQuery, List<BookingListResponse>>
{
    public async Task<List<BookingListResponse>> Handle(GetListBookingQuery request, CancellationToken cancellationToken)
    {
        var bookings = await unitOfWork.BookingRepository.GetAllAsync();

        var bookingsDto = mapper.Map<List<BookingListResponse>>(bookings);
        return bookingsDto;
    }
}
