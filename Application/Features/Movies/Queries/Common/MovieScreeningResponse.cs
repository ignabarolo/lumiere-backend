namespace Application.Features.Movies.Queries.Common;

public record MovieScreeningResponse(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate
);
