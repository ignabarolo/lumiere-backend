using Application.Features.Rooms.Queries.Common;

namespace Application.Features.Rooms.Queries.GetList;

public record class RoomListResponse(Guid Id, int RoomNumber, int Capacity, List<GetSeatDto> Seats);
