using Application.Features.Bookings.Queries.Common;
using Domain.Enums;

namespace Application.Features.Bookings.Queries.GetList;

public record BookingListResponse(
    Guid Id,
    DateTime Date,
    decimal Total,
    PaymentMethod PaymentMethod,
    ScreeningDto Screening);