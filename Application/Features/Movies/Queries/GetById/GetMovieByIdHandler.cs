using Application.Exceptions;
using Application.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Movies.Queries.GetById;

public class GetMovieByIdHandler(IMovieRepository movieRepository, IMapper mapper) : IRequestHandler<GetMovieByIdQuery, MovieResponse>
{
    public async Task<MovieResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movie = await movieRepository.GetByIdAsync(request.Id);
        if (movie == null) throw new NotFoundException($"The movie {request.Id} was not found");

        var dto = mapper.Map<MovieResponse>(movie);
        return dto;
    }
}