using MediatR;

namespace Application.Features.Screenings.Queries.GetById;

public record GetScreeningByIdQuery(Guid Id) : IRequest<ScreeningResponse>;
