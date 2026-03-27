using MediatR;

namespace Application.Features.Movies.Queries.GetMovieById;

public record GetMovieByIdQuery(Guid Id) : IRequest<MovieResponse>;
