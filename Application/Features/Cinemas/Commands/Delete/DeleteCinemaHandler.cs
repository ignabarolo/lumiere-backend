using Application.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Cinemas.Commands.Delete;

public class DeleteCinemaHandler(ICinemaRepository cinemaRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteCinemaCommand, Guid>
{
    public async Task<Guid> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
    {
        var cinema = await cinemaRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The cinema {request.Id} was not found");

        cinemaRepository.Delete(cinema);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return cinema.Id;
    }
}
