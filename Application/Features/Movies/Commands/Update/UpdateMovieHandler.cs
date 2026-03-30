using Domain.Interfaces;
using MediatR;

namespace Application.Features.Movies.Commands.Update;

public class UpdateMovieHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateMovieCommand, Guid>
{
    public async Task<Guid> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await unitOfWork.MovieRepository.GetByIdAsync(request.Id);

        if (movie == null) return new Guid();

        movie.Title = request.Title;
        movie.Genre = request.Genre;
        movie.Duration = TimeSpan.FromMinutes(request.DurationMinutes);
        movie.Classification = request.Classification;
        movie.State = request.State;

        unitOfWork.MovieRepository.Update(movie);
        await unitOfWork.SaveChangesAsync();

        return movie.Id;
    }
}
