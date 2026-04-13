using Application.Features.Rooms.Queries.Common;

namespace Application.Features.Rooms.Queries.GetById;

public record RoomResponse(Guid Id, int Room_Number, int Capacity, List<GetSeatDto> Seats);