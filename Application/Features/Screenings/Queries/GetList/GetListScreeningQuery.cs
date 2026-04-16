using MediatR;

namespace Application.Features.Screenings.Queries.GetList;

public record GetListScreeningQuery : IRequest<List<ScreeningListResponse>>
{
}
