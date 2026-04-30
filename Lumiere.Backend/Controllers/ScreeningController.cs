using Application.Features.Screenings.Commands.Create;
using Application.Features.Screenings.Commands.Delete;
using Application.Features.Screenings.Commands.Update;
using Application.Features.Screenings.Queries.GetById;
using Application.Features.Screenings.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lumiere.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreeningController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateScreeningCommand command)
        {
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await mediator.Send(new GetScreeningByIdQuery(id));
            return result is not null ? Ok(result) : NotFound();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetListScreeningQuery());
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateScreeningCommand command)
        {
            if (id != command.Id) return BadRequest("ID in URL does not match ID in body.");
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await mediator.Send(new DeleteScreeningCommand(id));
            return NoContent();
        }
    }
}
