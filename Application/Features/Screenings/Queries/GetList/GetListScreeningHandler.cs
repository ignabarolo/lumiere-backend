using Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Screenings.Queries.GetList;

public class GetListScreeningHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetListScreeningQuery, List<ScreeningListResponse>>
{
    public async Task<List<ScreeningListResponse>> Handle(GetListScreeningQuery request, CancellationToken cancellationToken)
    {
        var screenings = await unitOfWork.ScreeningRepository.GetAllAsync();
        var screeningsDto = mapper.Map<List<ScreeningListResponse>>(screenings);
        return screeningsDto;
    }
}
