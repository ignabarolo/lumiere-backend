using Application.Features.Movies.Queries.Common;

namespace Application.Features.Movies.Queries.GetList;

public record MovieListResponse(
    Guid Id,
    string Title,
    string Genre,
    string Classification,
    TimeSpan Duration,
    List<MovieScreeningResponse> Screenings
);
