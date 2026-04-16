namespace Application.Features.Screenings.Queries.GetList;

public record ScreeningListResponse
(
    Guid Id,
    string MovieTitle,
    string RoomNumber,
    DateTime StartTime,
    DateTime EndTime
);
