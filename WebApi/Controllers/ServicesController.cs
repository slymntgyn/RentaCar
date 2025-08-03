using Application.Features.Mediator.Commands.ServicesCommands;
using Application.Features.Mediator.Queries.ServicesQueries;
using Application.Features.Mediator.Results.ServicesResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<GetServicesQueryResult> result = await _mediator.Send(new GetServicesQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            try
            {
                GetServicesByIdQueryResult service = await _mediator.Send(new GetServicesByIdQuery(id));
                return Ok(service);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] CreateServicesCommand command)
        {
            await _mediator.Send(command);
            return Ok("Services başarılı bir şekilde eklendi.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] UpdateServicesCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location başarılı bir şekilde güncellendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _mediator.Send(new RemoveServicesCommand(id));
            return Ok("Location başarılı bir şekilde eklendi.");
        }
    }
}
