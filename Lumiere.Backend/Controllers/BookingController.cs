using Application.Features.Bookings.Commands.Create;
using Application.Features.Bookings.Queries.GetById;
using Application.Features.Bookings.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lumiere.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result }, new { id = result });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetBookingByIdQuery(id));
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await mediator.Send(new GetListBookingQuery());
        return result is not null ? Ok(result) : NotFound();
    }
}
