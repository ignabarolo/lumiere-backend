using Application.Features.Rooms.Commands.Create;
using Application.Features.Rooms.Queries.GetById;
using Domain.Entities;
using Xunit;

namespace Lumiere.Backend.Tests.Integration.Mapping;

public class RoomMappingTests : MappingTestBase
{
    [Fact]
    public void CreateRoomCommand_Deserializes_And_Maps_To_Room()
    {
        const string json = """
        {
            "roomNumber": 15,
            "capacity": 80,
            "cinemaId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "seats": [
                { "row": "B", "column": 1 },
                { "row": "B", "column": 2 }
            ]
        }
        """;

        AssertCommandMapping<CreateRoomCommand, Room>(json, room =>
        {
            Assert.Equal(15, room.Room_Number);
            Assert.Equal(80, room.Capacity);
            Assert.NotEqual(Guid.Empty, room.CinemaId);
            Assert.Equal(2, room.Seats.Count);
        });
    }

    [Fact]
    public void Room_Entity_Maps_To_RoomResponse()
    {
        var room = new Room
        {
            Id = Guid.NewGuid(),
            Room_Number = 25,
            Capacity = 150,
            Seats =
            [
                new Seat { Id = Guid.NewGuid(), Row = "A", Column = 1 }
            ]
        };

        var response = Mapper.Map<RoomResponse>(room);

        Assert.NotNull(response);
        Assert.Equal(room.Id, response.Id);
        Assert.Equal(25, response.Room_Number);
        Assert.Single(response.Seats);
    }
}
