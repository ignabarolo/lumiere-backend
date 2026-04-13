using Application.Features.Rooms.Commands.Create;
using Application.Features.Rooms.Commands.Delete;
using Application.Features.Rooms.Commands.Update;
using Application.Features.Rooms.Queries.GetById;
using Application.Features.Rooms.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lumiere.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoomCommand command)
    {
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetRoomByIdQuery(id));
        return result is not null ? Ok(result) : NotFound();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteRoomCommand(id));
        return NoContent();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRoomCommand command)
    {
        if (id != command.Id) return BadRequest("ID in URL does not match ID in body.");
        await mediator.Send(command);
        return NoContent();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await mediator.Send(new GetListRoomQuery());
        return result is not null ? Ok(result) : NotFound();
    }
}
