using Domain.Entities;
using MediatR;

namespace Application.Features.Screenings.Commands.Create;

public record CreateScreeningCommand(
    DateTime StartDate,
    DateTime EndDate, 
    Guid MovieId, 
    Guid RoomId, 
    List<Booking> Bookings) : IRequest<Guid>;
