using Application.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Screenings.Commands.Update;

public class UpdateScreeningHandler(IScreeningRepository screeningRepository, IMovieRepository movieRepository, IRoomRepository roomRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateScreeningCommand, Guid>
{
    public async Task<Guid> Handle(UpdateScreeningCommand request, CancellationToken cancellationToken)
    {
        var screening = await screeningRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The screening {request.Id} was not found");
        screening.StartDate = request.StartDate;
        screening.EndDate = request.EndDate;

        if (screening.MovieId != request.MovieId)
        {
            var movie = await movieRepository.GetByIdAsync(request.MovieId)
                ?? throw new NotFoundException($"The movie {request.MovieId} was not found");
            screening.Movie = movie;
        }

        if (screening.RoomId != request.RoomId)
        {
            var room = await roomRepository.GetByIdAsync(request.RoomId)
                ?? throw new NotFoundException($"The room {request.RoomId} was not found");
            screening.Room = room;
        }

        screeningRepository.Update(screening);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return screening.Id;
    }
}
