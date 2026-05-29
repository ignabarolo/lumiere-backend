using Application.Exceptions;
using Application.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Screenings.Queries.GetById;

public class GetScreeningByIdHandler(IScreeningRepository screeningRepository, IMapper mapper) : IRequestHandler<GetScreeningByIdQuery, ScreeningResponse>
{
    public async Task<ScreeningResponse> Handle(GetScreeningByIdQuery request, CancellationToken cancellationToken)
    {
        var screening = await screeningRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The screening {request.Id} was not found");

        var screeningDto = mapper.Map<ScreeningResponse>(screening);
        return screeningDto;
    }
}
