using Domain.Interfaces;
using MediatR;

namespace Application.Features.Movies.Queries.GetMovieById;

public class GetMovieByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetMovieByIdQuery, MovieResponse>
{
    public async Task<MovieResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movie = await unitOfWork.MovieRepository.GetByIdAsync(request.Id);
        if (movie == null) return null;

        return new MovieResponse(movie.Id, movie.Title, movie.Genre);
    }
}