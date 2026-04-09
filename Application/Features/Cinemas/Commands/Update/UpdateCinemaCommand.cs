using Domain.Enums;
using MediatR;

namespace Application.Features.Cinemas.Commands.Update;

public record UpdateCinemaCommand(Guid Id, string Address, State State) : IRequest<Guid>;
