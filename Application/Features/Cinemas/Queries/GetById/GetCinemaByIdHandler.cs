using Application.Exceptions;
using Application.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Cinemas.Queries.GetById;

public class GetCinemaByIdHandler(ICinemaRepository cinemaRepository, IMapper mapper) : IRequestHandler<GetCinemaByIdQuery, CinemaResponse>
{
    public async Task<CinemaResponse> Handle(GetCinemaByIdQuery request, CancellationToken cancellationToken)
    {
        var cinema = await cinemaRepository.GetByIdAsync(request.Id);
        if (cinema is null) throw new NotFoundException($"The cinema {request.Id} was not found.");

        var cinemaDto = mapper.Map<CinemaResponse>(cinema);
        return cinemaDto;
    }
}
