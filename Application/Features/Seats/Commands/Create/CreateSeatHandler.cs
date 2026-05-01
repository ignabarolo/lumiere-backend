using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using MediatR;
namespace Application.Features.Seats.Commands.Create;

public class CreateSeatHandler(ISeatRepository seatRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateSeatCommand, Guid>
{
    public async Task<Guid> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
    {
        var seat = mapper.Map<Seat>(request);
        await seatRepository.AddAsync(seat);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return seat.Id;
    }
}
