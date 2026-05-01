using Application.Features.Bookings.Commands.Create;
using Application.Features.Bookings.Queries.GetById;
using Domain.Entities;
using Domain.Enums;
using Xunit;

namespace Lumiere.Backend.Tests.Integration.Mapping;

public class BookingMappingTests : MappingTestBase
{
    [Fact]
    public void CreateBookingCommand_Deserializes_And_Maps_To_Booking()
    {
        const string json = """
        {
            "date": "2026-07-01T14:00:00",
            "total": 25.50,
            "paymentMethod": "Card",
            "screeningId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "userId": "8a7b3c1d-9e2f-4a56-b8c3-d1e2f3a4b5c6"
        }
        """;

        AssertCommandMapping<CreateBookingCommand, Booking>(json, booking =>
        {
            Assert.Equal(new DateTime(2026, 7, 1, 14, 0, 0), booking.Date);
            Assert.Equal(25.50m, booking.Total);
            Assert.Equal(PaymentMethod.Card, booking.PaymentMethod);
            Assert.NotEqual(Guid.Empty, booking.ScreeningId);
            Assert.NotEqual(Guid.Empty, booking.UserId);
        });
    }

    [Fact]
    public void Booking_Entity_Maps_To_BookingResponse()
    {
        var booking = new Booking
        {
            Id = Guid.NewGuid(),
            Date = new DateTime(2026, 7, 15, 18, 0, 0),
            Total = 45.00m,
            PaymentMethod = PaymentMethod.Transfer,
            ScreeningId = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
            User = new User { Id = Guid.NewGuid(), First_Name = "John", Last_Name = "Doe" },
            Screening = new Screening
            {
                Id = Guid.NewGuid(),
                StartDate = new DateTime(2026, 7, 15, 20, 0, 0),
                EndDate = new DateTime(2026, 7, 15, 22, 0, 0),
                MovieId = Guid.NewGuid(),
                Movie = new Movie { Title = "Inception" },
                RoomId = Guid.NewGuid(),
                Room = new Room { Room_Number = 7 }
            }
        };

        var response = Mapper.Map<BookingResponse>(booking);

        Assert.NotNull(response);
        Assert.Equal(booking.Id, response.Id);
        Assert.Equal(45.00m, response.Total);
        Assert.Equal("Inception", response.Screening.MovieTitle);
        Assert.Equal(7, response.Screening.RoomNumber);
    }
}
