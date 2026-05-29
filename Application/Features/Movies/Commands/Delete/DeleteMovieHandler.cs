using Application.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Movies.Commands.Delete;

public class DeleteMovieHandler(IMovieRepository movieRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteMovieCommand, Guid>
{
    public async Task<Guid> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await movieRepository.GetByIdAsync(request.Id);

        if (movie == null) throw new NotFoundException($"The movie {request.Id} was not found");

        movieRepository.Delete(movie);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return movie.Id;
    }
}
