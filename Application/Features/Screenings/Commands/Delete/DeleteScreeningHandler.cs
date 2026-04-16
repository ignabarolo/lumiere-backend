using Domain.Interfaces;
using Lumiere.Application.Exceptions;
using MediatR;

namespace Application.Features.Screenings.Commands.Delete;

public class DeleteScreeningHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteScreeningCommand, Guid>
{
    public async Task<Guid> Handle(DeleteScreeningCommand request, CancellationToken cancellationToken)
    {
        var screening = await unitOfWork.ScreeningRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The screening {request.Id} was not found");
        
        unitOfWork.ScreeningRepository.Delete(screening);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return screening.Id;
    }
}
