using Application.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Movies.Commands.Update;

public class UpdateMovieHandler(IMovieRepository movieRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateMovieCommand, Guid>
{
    public async Task<Guid> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await movieRepository.GetByIdAsync(request.Id);

        if (movie == null) throw new NotFoundException($"The movie {request.Id} was not found");

        movie.Title = request.Title;
        movie.Genre = request.Genre;
        movie.Duration = TimeSpan.FromMinutes(request.DurationMinutes);
        movie.Classification = request.Classification;
        movie.State = request.State;

        movieRepository.Update(movie);
        await unitOfWork.SaveChangesAsync();

        return movie.Id;
    }
}
