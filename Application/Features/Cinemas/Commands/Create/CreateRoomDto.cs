namespace Application.Features.Cinemas.Commands.Create;

public record GetRoomDto(
    int Room_Number,
    int Capacity,
    List<CreateSeatDto> Seats
);
