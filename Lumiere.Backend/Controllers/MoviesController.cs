using Application.Features.Movies.Commands.Create;
using Application.Features.Movies.Commands.Delete;
using Application.Features.Movies.Commands.Update;
using Application.Features.Movies.Queries.GetById;
using Application.Features.Movies.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lumiere.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMovieCommand command)
    {
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetMovieByIdQuery(id));
        return result is not null ? Ok(result) : NotFound();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetListByFilter([FromQuery] GetListMovieQuery query)
    {
        var result = await mediator.Send(query);
        return result is not null ? Ok(result) : NotFound();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateMovieCommand command, Guid id)
    {
        var idCreated = await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteMovieCommand(id));
        return NoContent();
    }
}
