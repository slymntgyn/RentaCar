using Application.Features.Mediator.Commands.FooterAdressCommands;
using Application.Features.Mediator.Queries.FooterAdressQueries;
using Application.Features.Mediator.Results.FooterAdressResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class footerAdresssController : ControllerBase
    {
        private readonly IMediator _mediator;

        public footerAdresssController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetFooterAddress()
        {

            List<GetFooterAdressQueryResult> result = await _mediator.Send(new GetFooterAdressQuery());
            return Ok(result);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetFooterAddressById(int id)
        {
            GetFooterAdressByIdQueryResult result = await _mediator.Send(new GetFooterAdressByIdQuery(id));
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAdressCommand createFooterAdressCommand)
        {
            await _mediator.Send(createFooterAdressCommand);
            return Ok("Footer adresi başarılı bir şekilde eklendi.");
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAdressCommand updateFooterAdressCommand)
        {
            await _mediator.Send(updateFooterAdressCommand);
            return Ok("Footer adresi başarılı bir şekilde güncellendi.");
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteFooterAddress(int id)
        {
            await _mediator.Send(new RemoveFooterAdressCommand(id));
            return Ok("Footer adresi başarılı bir şekilde silindi.");
        }
    }
}
