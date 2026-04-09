using MediatR;

namespace Application.Features.Cinemas.Queries.GetById;

public record GetCinemaByIdQuery(Guid Id) : IRequest<CinemaResponse>;
