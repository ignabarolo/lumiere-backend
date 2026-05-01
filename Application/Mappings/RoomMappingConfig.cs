using Application.Features.Rooms.Commands.Create;
using Application.Features.Rooms.Queries.GetById;
using Application.Features.Rooms.Queries.GetList;
using Domain.Entities;
using Mapster;

namespace Application.Mappings;

public class RoomMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateRoomCommand, Room>()
            .Map(dest => dest.Room_Number, src => src.RoomNumber);

        config.NewConfig<Room, RoomResponse>();
        config.NewConfig<Room, RoomListResponse>();
    }
}
