namespace Application.Features.Cinemas.Queries.Common;

public record GetSeatDto(
    Guid Id,
    string Row,
    string Column
);
