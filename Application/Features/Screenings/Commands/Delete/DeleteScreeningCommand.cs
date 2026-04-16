using MediatR;

namespace Application.Features.Screenings.Commands.Delete;

public record DeleteScreeningCommand(Guid Id) : IRequest<Guid>;
