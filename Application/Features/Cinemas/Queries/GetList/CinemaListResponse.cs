using Application.Features.Cinemas.Queries.Common;

namespace Application.Features.Cinemas.Queries.GetList;

public record CinemaListResponse(string Address, List<GetRoomDto> Rooms);
