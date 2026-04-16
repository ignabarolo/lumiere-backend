using MediatR;

namespace Application.Features.Bookings.Queries.GetById;

public record GetBookingByIdQuery(Guid Id) : IRequest<BookingResponse>;
