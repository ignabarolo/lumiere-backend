using MediatR;

namespace Application.Features.Movies.Commands.CreateCommand;

public record CreateMovieCommand(
    string Title,
    string Genre,
    int DurationMinutes,
    string Classification
) : IRequest<Guid>;
