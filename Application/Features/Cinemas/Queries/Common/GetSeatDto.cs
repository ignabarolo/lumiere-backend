namespace Application.Features.Cinemas.Queries.Common;

public record CreateSeat(
    Guid Id,
    string Row,
    string Column
);
