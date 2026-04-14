using Application.Features.Seats.Commands.Create;
using Application.Features.Seats.Queries.GetById;
using Application.Features.Seats.Queries.GetList;
using Domain.Entities;
using Mapster;

namespace Application.Mappings;

public class SeatMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateSeatCommand, Seat>();
        config.NewConfig<Seat, SeatResponse>();
        config.NewConfig<Seat, SeatListResponse>();
    }
}
