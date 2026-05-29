using Application.Features.Cinemas.Commands.Create;
using Application.Features.Cinemas.Queries.GetById;
using Domain.Entities;
using Mapster;

namespace Application.Mappings;

public class CinemaMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCinemaCommand, Cinema>();
        config.NewConfig<Cinema, CinemaResponse>();

        config.NewConfig<CreateRoomDto, Room>();

        config.NewConfig<CreateSeatDto, Seat>();
    }
}
