using Application.Features.Cinemas.Commands.Create;
using Application.Features.Cinemas.Commands.Delete;
using Application.Features.Cinemas.Commands.Update;
using Application.Features.Cinemas.Queries.GetById;
using Application.Features.Cinemas.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lumiere.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CinemaController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCinemaCommand command)
    {
        var id = await mediator.Send(command);
        return Ok(id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetCinemaByIdQuery(id));
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetList()
    {
        var result = await mediator.Send(new GetListCinemaQuery());
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteCinemaCommand(id));
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateCinemaCommand command, Guid id)
    {
        if (id != command.Id) return BadRequest("ID in URL does not match ID in body.");
        await mediator.Send(command);
        return NoContent();
    }
}
