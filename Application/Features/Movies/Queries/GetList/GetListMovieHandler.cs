using Application.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Movies.Queries.GetList;

public class GetListMovieHandler(IMovieRepository movieRepository, IMapper mapper) : IRequestHandler<GetListMovieQuery, List<MovieListResponse>>
{
    public async Task<List<MovieListResponse>> Handle(GetListMovieQuery request, CancellationToken cancellationToken)
    {
        var entities = await movieRepository.GetMoviesByFilterAsync(request.filter.ToLower());

        var dto = mapper.Map<List<MovieListResponse>>(entities);
        return dto;
    }
}
