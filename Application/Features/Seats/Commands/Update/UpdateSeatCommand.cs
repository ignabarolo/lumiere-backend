using MediatR;

namespace Application.Features.Seats.Commands.Update;

public record UpdateSeatCommand(Guid Id, string Row, int Column) : IRequest<Guid>;
