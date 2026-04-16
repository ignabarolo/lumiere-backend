using Application.Features.Bookings.Queries.Common;
using Domain.Enums;

namespace Application.Features.Bookings.Queries.GetById;

public record BookingResponse(
    Guid Id,
    DateTime Date,
    decimal Total,
    PaymentMethod PaymentMethod,
    ScreeningDto Screening);