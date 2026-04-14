using MediatR;

namespace Application.Features.Seats.Commands.Delete;

public record DeleteSeatCommand(Guid Id) : IRequest<Guid>;
