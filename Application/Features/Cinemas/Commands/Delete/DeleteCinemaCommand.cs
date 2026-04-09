using MediatR;

namespace Application.Features.Cinemas.Commands.Delete;

public record DeleteCinemaCommand(Guid Id) : IRequest<Guid>;
