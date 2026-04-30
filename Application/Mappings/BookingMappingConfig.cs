using Application.Features.Bookings.Commands.Create;
using Application.Features.Bookings.Queries.Common;
using Application.Features.Bookings.Queries.GetById;
using Application.Features.Bookings.Queries.GetList;
using Domain.Entities;
using Mapster;

namespace Application.Mappings;

public class BookingMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateBookingCommand, Booking>();
        config.NewConfig<Booking, BookingResponse>()
            .Map(dest => dest.Screening, src => new ScreeningDto(
                src.Screening.Id,
                src.Screening.Movie.Title,
                src.Screening.Room.Room_Number,
                src.Screening.StartDate,
                src.Screening.EndDate
            ));
        
        config.NewConfig<Booking, BookingListResponse>()
            .Map(dest => dest.Screening, src => new ScreeningDto(
                src.Screening.Id,
                src.Screening.Movie.Title,
                src.Screening.Room.Room_Number,
                src.Screening.StartDate,
                src.Screening.EndDate
            ));
    }
}
