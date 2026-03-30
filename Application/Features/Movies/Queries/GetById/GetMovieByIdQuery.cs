using MediatR;

namespace Application.Features.Movies.Queries.GetById;

public record GetMovieByIdQuery(Guid Id) : IRequest<MovieResponse>;
