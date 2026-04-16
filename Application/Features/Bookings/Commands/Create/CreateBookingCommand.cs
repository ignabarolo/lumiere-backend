using Domain.Enums;
using MediatR;

namespace Application.Features.Bookings.Commands.Create;

public record CreateBookingCommand(
    DateTime Date,
    decimal Total,
    PaymentMethod PaymentMethod,
    Guid UserId,
    Guid ScreeningId) : IRequest<Guid>;
