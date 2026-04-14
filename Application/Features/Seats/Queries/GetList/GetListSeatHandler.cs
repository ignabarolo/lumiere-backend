using Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Seats.Queries.GetList;

public class GetListSeatHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetListSeatQuery, List<SeatListResponse>>
{
    public async Task<List<SeatListResponse>> Handle(GetListSeatQuery request, CancellationToken cancellationToken)
    {
        var seats = await unitOfWork.SeatRepository.GetAllAsync();
        var seatsDto = mapper.Map<List<SeatListResponse>>(seats);
        return seatsDto;
    }
}
