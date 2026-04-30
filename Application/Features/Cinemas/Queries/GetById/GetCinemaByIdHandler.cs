using Domain.Interfaces;
using Application.Exceptions;
using MapsterMapper;
using MediatR;

namespace Application.Features.Cinemas.Queries.GetById;

public class GetCinemaByIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetCinemaByIdQuery, CinemaResponse>
{
    public async Task<CinemaResponse> Handle(GetCinemaByIdQuery request, CancellationToken cancellationToken)
    {
        var cinema = await unitOfWork.CinemaRepository.GetByIdAsync(request.Id);
        if (cinema is null) throw new NotFoundException($"The cinema {request.Id} was not found.");

        var cinemaDto = mapper.Map<CinemaResponse>(cinema);
        return cinemaDto;
    }
}
