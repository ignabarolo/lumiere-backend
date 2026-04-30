using Domain.Interfaces;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Cinemas.Commands.Delete;

public class DeleteCinemaHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCinemaCommand, Guid>
{
    public async Task<Guid> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
    {
        var cinema = await unitOfWork.CinemaRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException($"The cinema {request.Id} was not found");

        unitOfWork.CinemaRepository.Delete(cinema);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return cinema.Id;
    }
}
