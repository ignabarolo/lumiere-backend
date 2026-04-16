namespace Application.Features.Screenings.Queries.GetById;

public record ScreeningResponse(
    Guid Id,
    string MovieTitle,
    string RoomNumber,
    DateTime StartTime,
    DateTime EndTime
);