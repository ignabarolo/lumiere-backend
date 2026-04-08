using Application.Features.Movies.Queries.Common;

namespace Application.Features.Movies.Queries.GetById;

public record MovieResponse(
    Guid Id,
    string Title,
    string Genre,
    string Classification,
    TimeSpan Duration,
    List<MovieScreeningResponse> Screenings
);
