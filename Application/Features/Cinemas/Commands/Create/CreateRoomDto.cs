namespace Application.Features.Cinemas.Commands.Create;

public record CreateRoomDto(
    int Room_Number,
    int Capacity,
    List<CreateSeatDto> Seats
);
