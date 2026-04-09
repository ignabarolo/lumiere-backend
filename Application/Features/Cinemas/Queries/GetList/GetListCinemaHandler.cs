using Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Cinemas.Queries.GetList;

public class GetListCinemaHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetListCinemaQuery, List<CinemaListResponse>>
{
    public async Task<List<CinemaListResponse>> Handle(GetListCinemaQuery request, CancellationToken cancellationToken)
    {
        var cinemas = await unitOfWork.CinemaRepository.GetAllAsync();

        var cinemasDto = mapper.Map<List<CinemaListResponse>>(cinemas);
        return cinemasDto;
    }
}
