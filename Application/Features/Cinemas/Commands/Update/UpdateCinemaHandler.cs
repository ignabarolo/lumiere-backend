using Application.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Cinemas.Commands.Update;

public class UpdateCinemaHandler(ICinemaRepository cinemaRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateCinemaCommand, Guid>
{
    public async Task<Guid> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
    {
        var cinema = await cinemaRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The movie {request.Id} was not found");

        cinema.Address = request.Address;
        cinema.State = request.State;

        cinemaRepository.Update(cinema);
        await unitOfWork.SaveChangesAsync();

        return cinema.Id;
    }
}
