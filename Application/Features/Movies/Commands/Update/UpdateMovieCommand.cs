using Domain.Enums;
using MediatR;

namespace Application.Features.Movies.Commands.Update;

public record UpdateMovieCommand(
    Guid Id,
    string Title,
    string Genre,
    int DurationMinutes,
    string Classification,
    State State
 ) : IRequest<Guid>;
