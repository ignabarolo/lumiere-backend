using MediatR;

namespace Application.Features.Movies.Commands.Delete;

public record DeleteMovieCommand(Guid Id) : IRequest<Guid>;

