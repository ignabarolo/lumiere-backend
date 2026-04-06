using MediatR;

namespace Application.Features.Movies.Queries.GetList;

public record GetListMovieQuery(string filter) : IRequest<List<MovieListResponse>>;
