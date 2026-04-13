namespace Application.Features.Rooms.Queries.Common;

public record GetSeatDto(
    Guid Id,
    string Row,
    string Column
);
