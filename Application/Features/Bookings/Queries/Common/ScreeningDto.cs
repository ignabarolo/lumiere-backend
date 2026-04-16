namespace Application.Features.Bookings.Queries.Common;

public record ScreeningDto(
    Guid Id,
    string MovieTitle,
    int RoomNumber,
    DateTime StartTime,
    DateTime EndTime
);
