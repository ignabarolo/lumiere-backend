using Application.Features.Cinemas.Commands.Create;
using Application.Features.Cinemas.Queries.GetById;
using Domain.Entities;
using Xunit;

namespace Lumiere.Backend.Tests.Integration.Mapping;

public class CinemaMappingTests : MappingTestBase
{
    [Fact]
    public void CreateCinemaCommand_Deserializes_And_Maps_To_Cinema()
    {
        const string json = """
        {
            "address": "123 Main St",
            "rooms": [
                {
                    "roomNumber": 1,
                    "capacity": 100,
                    "seats": [
                        { "row": "A", "column": 1 },
                        { "row": "A", "column": 2 }
                    ]
                }
            ]
        }
        """;

        AssertCommandMapping<CreateCinemaCommand, Cinema>(json, cinema =>
        {
            Assert.Equal("123 Main St", cinema.Address);
            Assert.Single(cinema.Rooms);
            Assert.Equal(1, cinema.Rooms.First().RoomNumber);
            Assert.Equal(2, cinema.Rooms.First().Seats.Count);
        });
    }

    [Fact]
    public void Cinema_Entity_Maps_To_CinemaResponse()
    {
        var cinema = new Cinema
        {
            Id = Guid.NewGuid(),
            Address = "456 Oak Ave",
            Rooms =
            [
                new Room
                {
                    Id = Guid.NewGuid(),
                    RoomNumber = 10,
                    Capacity = 200,
                    Seats =
                    [
                        new Seat { Id = Guid.NewGuid(), Row = "A", Column = 1 },
                        new Seat { Id = Guid.NewGuid(), Row = "A", Column = 2 }
                    ]
                }
            ]
        };

        var response = Mapper.Map<CinemaResponse>(cinema);

        Assert.NotNull(response);
        Assert.Equal(cinema.Address, response.Address);
        Assert.Single(response.Rooms);
        Assert.Equal(10, response.Rooms[0].RoomNumber);
        Assert.Equal(2, response.Rooms[0].Seats.Count);
    }
}
