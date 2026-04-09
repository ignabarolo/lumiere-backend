using Domain.Interfaces;
using Lumiere.Application.Exceptions;
using MediatR;

namespace Application.Features.Cinemas.Commands.Update;

public class UpdateCinemaHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCinemaCommand, Guid>
{
    public async Task<Guid> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
    {
        var cinema = await unitOfWork.CinemaRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The movie {request.Id} was not found");

        cinema.Address = request.Address;
        cinema.State = request.State;

        unitOfWork.CinemaRepository.Update(cinema);
        await unitOfWork.SaveChangesAsync();

        return cinema.Id;
    }
}
