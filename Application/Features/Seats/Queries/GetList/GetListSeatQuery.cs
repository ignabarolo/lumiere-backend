using MediatR;

namespace Application.Features.Seats.Queries.GetList;

public record GetListSeatQuery() : IRequest<List<SeatListResponse>>;
