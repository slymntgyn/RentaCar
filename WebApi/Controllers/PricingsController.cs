using Application.Features.Mediator.Commands.PricingCommands;
using Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Application.Features.Mediator.Results.PricingResult.GetPricingQueryResult> result = await _mediator.Send(new GetPricingQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Application.Features.Mediator.Results.PricingResult.GetPricingByIdQueryResult result = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location başarılı bir şekilde eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location başarılı bir şekilde güncellendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Location başarılı bir şekilde silindi.");
        }

    }
}
