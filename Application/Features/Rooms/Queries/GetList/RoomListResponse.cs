using Application.Features.Rooms.Queries.Common;

namespace Application.Features.Rooms.Queries.GetList;

public record class RoomListResponse(Guid Id, int Room_Number, int Capacity, List<GetSeatDto> Seats);
