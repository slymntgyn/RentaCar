using Application.Features.Mediator.Commands.SocialMediaCommands;
using Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IMediator mediator;

        public SocialMediaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Application.Features.Mediator.Results.SocialMediaResult.GetSocialMediaQueryResult> result = await mediator.Send(new GetSocialMediaQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Application.Features.Mediator.Results.SocialMediaResult.GetSocialMediaByIdQueryResult result = await mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaCommand command)
        {
            await mediator.Send(command);
            return Ok("Sosyal medya başarılı bir şekilde eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialMediaCommand command)
        {
            await mediator.Send(command);
            return Ok("Sosyal medya başarılı bir şekilde güncellendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok("Sosyal medya başarılı bir şekilde silindi.");
        }

    }
}
