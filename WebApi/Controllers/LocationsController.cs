using Application.Features.Mediator.Commands.LocationCommands;
using Application.Features.Mediator.Queries.LocationQueries;
using Application.Features.Mediator.Results.LocationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetLocationList()
        {
            List<GetLocationQueryResult> result = await _mediator.Send
                (
                    new GetLocationQuery()
                );
            return Ok(result);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            GetLocationByIdQueryResult result = await _mediator.Send
                (
                    new GetLocationByIdQuery(id)
                );
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand createLocationCommand)
        {
            await _mediator.Send(createLocationCommand);
            return Ok("Location başarılı bir şekilde eklendi.");
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand updateLocationCommand)
        {
            await _mediator.Send(updateLocationCommand);
            return Ok("Location başarılı bir şekilde güncellendi.");
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Location başarılı bir şekilde silindi.");
        }

    }
}
