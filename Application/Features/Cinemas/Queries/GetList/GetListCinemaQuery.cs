using MediatR;

namespace Application.Features.Cinemas.Queries.GetList;

public record GetListCinemaQuery : IRequest<List<CinemaListResponse>>;
