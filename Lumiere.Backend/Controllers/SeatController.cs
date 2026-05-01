using Application.Features.Seats.Commands.Create;
using Application.Features.Seats.Commands.Delete;
using Application.Features.Seats.Commands.Update;
using Application.Features.Seats.Queries.GetById;
using Application.Features.Seats.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lumiere.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeatController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSeatCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetSeatByIdQuery(id));
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await mediator.Send(new GetListSeatQuery());
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteSeatCommand(id));
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSeatCommand command)
    {
        if (id != command.Id) return BadRequest("ID in URL does not match ID in body.");
        var result = await mediator.Send(command);
        return NoContent();
    }
}
