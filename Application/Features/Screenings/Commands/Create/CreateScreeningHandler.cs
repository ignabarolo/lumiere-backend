using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Screenings.Commands.Create;

public class CreateScreeningHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateScreeningCommand, Guid>
{
    public async Task<Guid> Handle(CreateScreeningCommand request, CancellationToken cancellationToken)
    {
        var screening = mapper.Map<Screening>(request);
        await unitOfWork.ScreeningRepository.AddAsync(screening);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return screening.Id;
    }
}
