using Domain.Entities;
using Domain.Enums;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Movies.Commands.Create;

public class CreateMovieHandler(IMovieRepository movieRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateMovieCommand, Guid>
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

        await movieRepository.AddAsync(movie);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return movie.Id;
    }
}
