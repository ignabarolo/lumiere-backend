using Application.Features.Seats.Commands.Create;
using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Seats.Create;

public class CreateSeatHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateSeatCommand, Guid>
{
    public async Task<Guid> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
    {
        var seat = mapper.Map<Seat>(request);
        await unitOfWork.SeatRepository.AddAsync(seat);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return seat.Id;
    }
}
