using Application.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Cinemas.Queries.GetList;

public class GetListCinemaHandler(ICinemaRepository cinemaRepository, IMapper mapper) : IRequestHandler<GetListCinemaQuery, List<CinemaListResponse>>
{
    public async Task<List<CinemaListResponse>> Handle(GetListCinemaQuery request, CancellationToken cancellationToken)
    {
        var cinemas = await cinemaRepository.GetAllAsync();

        var cinemasDto = mapper.Map<List<CinemaListResponse>>(cinemas);
        return cinemasDto;
    }
}
