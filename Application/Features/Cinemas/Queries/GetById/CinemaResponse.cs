using Application.Features.Cinemas.Queries.Common;

namespace Application.Features.Cinemas.Queries.GetById;

public record CinemaResponse(string Address, List<GetRoomDto> Rooms);
