using Domain.Interfaces;
using MediatR;

namespace Application.Features.Movies.Queries.GetMovieById;

public class GetMovieByIdHandler(IMovieRepository repository) : IRequestHandler<GetMovieByIdQuery, MovieResponse>
{
    public async Task<MovieResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movie = await repository.GetByIdAsync(request.Id);
        if (movie == null) return null;

        return new MovieResponse(movie.Id, movie.Title, movie.Genre);
    }
}