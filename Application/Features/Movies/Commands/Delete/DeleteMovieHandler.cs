using Domain.Interfaces;
using MediatR;

namespace Application.Features.Movies.Commands.Delete;

public class DeleteMovieHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteMovieCommand, Guid>
{
    public async Task<Guid> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await unitOfWork.MovieRepository.GetByIdAsync(request.Id);

        if (movie == null) return Guid.Empty;

        unitOfWork.MovieRepository.Delete(movie);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return movie.Id;
    }
}
