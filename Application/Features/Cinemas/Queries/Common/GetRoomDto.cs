namespace Application.Features.Cinemas.Queries.Common;

public record GetRoomDto(
    Guid Id,
    int Room_Number,
    int Capacity,
    List<GetSeatDto> Seats
);
