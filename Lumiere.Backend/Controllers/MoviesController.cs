using Application.Features.Movies.Commands.CreateCommand;
using Application.Features.Movies.Queries.GetMovieById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lumiere.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateMovieCommand command)
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
}
