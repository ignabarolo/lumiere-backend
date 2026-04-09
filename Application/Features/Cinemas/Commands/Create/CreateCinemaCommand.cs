using MediatR;

namespace Application.Features.Cinemas.Commands.Create;

public record CreateCinemaCommand(string Address, List<GetRoomDto> Rooms) : IRequest<Guid>;
