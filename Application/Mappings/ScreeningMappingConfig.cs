using Application.Features.Screenings.Queries.GetById;
using Application.Features.Screenings.Queries.GetList;
using Domain.Entities;
using Mapster;

namespace Application.Mappings;

internal class ScreeningMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Screening, ScreeningResponse>()
            .Map(dest => dest.StartTime, src => src.StartDate)
            .Map(dest => dest.EndTime, src => src.EndDate)
            .Map(dest => dest.MovieTitle, src => src.Movie.Title)
            .Map(dest => dest.RoomNumber, src => src.Room.Room_Number);
        
        config.NewConfig<Screening, ScreeningListResponse>()
            .Map(dest => dest.StartTime, src => src.StartDate)
            .Map(dest => dest.EndTime, src => src.EndDate)
            .Map(dest => dest.MovieTitle, src => src.Movie.Title)
            .Map(dest => dest.RoomNumber, src => src.Room.Room_Number);
    }
}
