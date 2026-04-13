using MediatR;

namespace Application.Features.Rooms.Commands.Create;

public record CreateRoomCommand(int RoomNumber, int Capacity, Guid CinemaId, List<CreateSeatDto> Seats) : IRequest<Guid>;
