using Application.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Seats.Queries.GetList;

public class GetListSeatHandler(ISeatRepository seatRepository, IMapper mapper) : IRequestHandler<GetListSeatQuery, List<SeatListResponse>>
{
    public async Task<List<SeatListResponse>> Handle(GetListSeatQuery request, CancellationToken cancellationToken)
    {
        var seats = await seatRepository.GetAllAsync();
        var seatsDto = mapper.Map<List<SeatListResponse>>(seats);
        return seatsDto;
    }
}
