using MediatR;

namespace Application.Features.Bookings.Commands.Delete;

public record DeleteBookingCommand(Guid Id) : IRequest<Guid>;
