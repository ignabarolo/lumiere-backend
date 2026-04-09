using Application.Features.Cinemas.Commands.Create;
using Application.Features.Cinemas.Queries.GetById;
using Domain.Entities;
using Mapster;

namespace Application.Mappings;

public class CinemaMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Cinema, CreateCinemaCommand>();
        config.NewConfig<Cinema, CinemaResponse>();
    }
}
