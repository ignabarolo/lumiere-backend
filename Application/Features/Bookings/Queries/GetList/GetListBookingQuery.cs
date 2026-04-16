using MediatR;

namespace Application.Features.Bookings.Queries.GetList;

public class GetListBookingQuery : IRequest<List<BookingListResponse>>;
