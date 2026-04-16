using Domain.Interfaces;
using Lumiere.Application.Exceptions;
using MapsterMapper;
using MediatR;

namespace Application.Features.Screenings.Queries.GetById;

public class ScreeningHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetScreeningByIdQuery, ScreeningResponse>
{
    public async Task<ScreeningResponse> Handle(GetScreeningByIdQuery request, CancellationToken cancellationToken)
    {
        var screening = await unitOfWork.ScreeningRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException($"The screening {request.Id} was not found");

        var screeningDto = mapper.Map<ScreeningResponse>(screening);
        return screeningDto;
    }
}
