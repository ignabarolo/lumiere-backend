using Domain.Interfaces;
using Lumiere.Application.Exceptions;
using MapsterMapper;
using MediatR;

namespace Application.Features.Seats.Queries.GetById;

public class GetSeatByIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetSeatByIdQuery, SeatResponse>
{
    public async Task<SeatResponse> Handle(GetSeatByIdQuery request, CancellationToken cancellationToken)
    {
        var seat = await unitOfWork.SeatRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"Seat with ID {request.Id} not found.");

        var seatDto = mapper.Map<SeatResponse>(seat);
        return seatDto;
    }
}
