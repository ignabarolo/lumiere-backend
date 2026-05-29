namespace Application.Features.Cinemas.Commands.Create;

public record CreateRoomDto(
    int RoomNumber,
    int Capacity,
    List<CreateSeatDto> Seats
);
