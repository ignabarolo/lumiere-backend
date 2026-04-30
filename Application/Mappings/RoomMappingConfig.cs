using Application.Features.Rooms.Commands.Create;
using Domain.Entities;
using Mapster;

namespace Application.Mappings;

public class RoomMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateRoomCommand, Room>();
    }
}
