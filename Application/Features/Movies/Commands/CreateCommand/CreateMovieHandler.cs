using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Movies.Commands.CreateCommand;

public class CreateMovieHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateMovieCommand, Guid>
{
    public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = new Movie
        {
            Title = request.Title,
            Genre = request.Genre,
            Duration = TimeSpan.FromMinutes(request.DurationMinutes),
            Classification = request.Classification,
            State = State.Active,
        };

        await unitOfWork.MovieRepository.AddAsync(movie);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return movie.Id;
    }
}
