using Domain.Interfaces;
using MediatR;

namespace Application.Features.Movies.Queries.GetList;

public class GetListMovieHandle(IUnitOfWork unitOfWork) : IRequestHandler<GetListMovieQuery, List<MovieListResponse>>
{
    public async Task<List<MovieListResponse>> Handle(GetListMovieQuery request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.MovieRepository.GetMoviesByFilterAsync(request.filter.ToLower());

        return entities.Select(m => new MovieListResponse
        (
            m.Id,
            m.Title,
            m.Genre,
            m.Classification,
            m.Duration
        )).ToList();
    }
}
