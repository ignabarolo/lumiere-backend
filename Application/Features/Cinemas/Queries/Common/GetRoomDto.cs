namespace Application.Features.Cinemas.Queries.Common;

public record GetRoomDto(
    Guid Id,
    int RoomNumber,
    int Capacity,
    List<GetSeatDto> Seats
);
