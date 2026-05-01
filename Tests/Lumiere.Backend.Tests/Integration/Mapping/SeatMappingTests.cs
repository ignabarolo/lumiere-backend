using Application.Features.Seats.Commands.Create;
using Application.Features.Seats.Queries.GetById;
using Domain.Entities;
using Xunit;

namespace Lumiere.Backend.Tests.Integration.Mapping;

public class SeatMappingTests : MappingTestBase
{
    [Fact]
    public void CreateSeatCommand_Deserializes_And_Maps_To_Seat()
    {
        const string json = """
        {
            "row": "C",
            "column": 5,
            "roomId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        }
        """;

        AssertCommandMapping<CreateSeatCommand, Seat>(json, seat =>
        {
            Assert.Equal("C", seat.Row);
            Assert.Equal(5, seat.Column);
            Assert.NotEqual(Guid.Empty, seat.RoomId);
        });
    }

    [Fact]
    public void Seat_Entity_Maps_To_SeatResponse()
    {
        var seat = new Seat
        {
            Id = Guid.NewGuid(),
            Row = "D",
            Column = 12
        };

        var response = Mapper.Map<SeatResponse>(seat);

        Assert.NotNull(response);
        Assert.Equal("D", response.Row);
        Assert.Equal(12, response.Column);
    }
}
