using Application.Features.Screenings.Commands.Create;
using Application.Features.Screenings.Queries.GetById;
using Domain.Entities;
using Xunit;

namespace Lumiere.Backend.Tests.Integration.Mapping;

public class ScreeningMappingTests : MappingTestBase
{
    [Fact]
    public void CreateScreeningCommand_Deserializes_And_Maps_To_Screening()
    {
        const string json = """
        {
            "startDate": "2026-06-15T18:30:00",
            "endDate": "2026-06-15T20:45:00",
            "movieId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "roomId": "8a7b3c1d-9e2f-4a56-b8c3-d1e2f3a4b5c6"
        }
        """;

        AssertCommandMapping<CreateScreeningCommand, Screening>(json, screening =>
        {
            Assert.Equal(new DateTime(2026, 6, 15, 18, 30, 0), screening.StartDate);
            Assert.Equal(new DateTime(2026, 6, 15, 20, 45, 0), screening.EndDate);
            Assert.NotEqual(Guid.Empty, screening.MovieId);
            Assert.NotEqual(Guid.Empty, screening.RoomId);
        });
    }

    [Fact]
    public void Screening_Entity_Maps_To_ScreeningResponse_With_Navigation_Properties()
    {
        var movieId = Guid.NewGuid();
        var screening = new Screening
        {
            Id = Guid.NewGuid(),
            StartDate = new DateTime(2026, 6, 15, 20, 0, 0),
            EndDate = new DateTime(2026, 6, 15, 22, 30, 0),
            MovieId = movieId,
            Movie = new Movie { Id = movieId, Title = "Avatar" },
            RoomId = Guid.NewGuid(),
            Room = new Room { Id = Guid.NewGuid(), Room_Number = 5 }
        };

        var response = Mapper.Map<ScreeningResponse>(screening);

        Assert.NotNull(response);
        Assert.Equal(screening.StartDate, response.StartTime);
        Assert.Equal("Avatar", response.MovieTitle);
        Assert.Equal("5", response.RoomNumber);
    }
}
