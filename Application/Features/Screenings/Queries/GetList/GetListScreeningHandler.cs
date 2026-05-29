using Application.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Screenings.Queries.GetList;

public class GetListScreeningHandler(IScreeningRepository screeningRepository, IMapper mapper) : IRequestHandler<GetListScreeningQuery, List<ScreeningListResponse>>
{
    public async Task<List<ScreeningListResponse>> Handle(GetListScreeningQuery request, CancellationToken cancellationToken)
    {
        var screenings = await screeningRepository.GetAllAsync();
        var screeningsDto = mapper.Map<List<ScreeningListResponse>>(screenings);
        return screeningsDto;
    }
}
