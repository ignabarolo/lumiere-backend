using MediatR;

namespace Application.Features.Seats.Queries.GetById;

public record GetSeatByIdQuery(Guid Id) : IRequest<SeatResponse>;
