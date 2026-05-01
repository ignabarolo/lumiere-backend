using Application.Exceptions;
using Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Seats.Queries.GetById;

public class GetSeatByIdHandler(ISeatRepository seatRepository, IMapper mapper) : IRequestHandler<GetSeatByIdQuery, SeatResponse>
{
    public async Task<SeatResponse> Handle(GetSeatByIdQuery request, CancellationToken cancellationToken)
    {
        var seat = await seatRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"Seat with ID {request.Id} not found.");

        var seatDto = mapper.Map<SeatResponse>(seat);
        return seatDto;
    }
}
