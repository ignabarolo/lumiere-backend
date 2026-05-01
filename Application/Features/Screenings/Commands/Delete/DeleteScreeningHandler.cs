using Application.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Screenings.Commands.Delete;

public class DeleteScreeningHandler(IScreeningRepository screeningRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteScreeningCommand, Guid>
{
    public async Task<Guid> Handle(DeleteScreeningCommand request, CancellationToken cancellationToken)
    {
        var screening = await screeningRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The screening {request.Id} was not found");

        screeningRepository.Delete(screening);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return screening.Id;
    }
}
