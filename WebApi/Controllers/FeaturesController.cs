using Application.Features.Mediator.Commands.FeatureCommands;
using Application.Features.Mediator.Queries.FeatureQueries;
using Application.Features.Mediator.Results.FeatureResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetFeatureList()
        {
            List<GetFeatureQueryResult> result = await _mediator.Send
                (
                    new GetFeatureQuery()
                );
            return Ok(result);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            GetFeatureByIdQueryResult result = await _mediator.Send
                (
                    new GetFeatureByIdQuery(id)
                );

            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand createFeatureCommand)
        {
            await _mediator.Send(createFeatureCommand);
            return Ok("Feature başarılı bir şekilde eklendi.");
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand updateFeatureCommand)
        {
            await _mediator.Send(updateFeatureCommand);
            return Ok("Feature başarılı bir şekilde güncellendi.");
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Feature başarılı bir şekilde silindi.");
        }
    }
}