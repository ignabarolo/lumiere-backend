using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Cinemas.Commands.Create;

public class CreateCinemaHandler(ICinemaRepository cinemaRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateCinemaCommand, Guid>
{
    public async Task<Guid> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Cinema>(request);
        await cinemaRepository.AddAsync(entity);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
