using Application.Features.CQRS.Commands.AboutCommands;
using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.CQRS.Results.AboutResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommendsHandler _createAboutCommendsHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly RemoveAboutCommendsHandler _removeAboutCommendsHandler;
        private readonly UpdateAboutCommendsHandler _updateAboutCommendsHandler;

        public AboutsController(CreateAboutCommendsHandler createAboutCommendsHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, RemoveAboutCommendsHandler removeAboutCommendsHandler, UpdateAboutCommendsHandler updateAboutCommendsHandler)
        {
            _createAboutCommendsHandler = createAboutCommendsHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _removeAboutCommendsHandler = removeAboutCommendsHandler;
            _updateAboutCommendsHandler = updateAboutCommendsHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAboutList()
        {
            List<GetAboutByIdQueryResult> result = await _getAboutQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            GetAboutByIdQueryResult? result = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            if (result == null)
            {
                return NotFound("About not found");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommends request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data");
            }
            await _createAboutCommendsHandler.Handle(request);
            return Ok("Hakkında bilgisi eklendi");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbout(int id, UpdateAboutCommends request)
        {
            if (id != request.Id)
            {
                return BadRequest("ID mismatch");
            }
            await _updateAboutCommendsHandler.Handle(request);
            return Ok("Hakkında bilgisi güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _removeAboutCommendsHandler.Handle(new RemoveAboutCommends(id));
            return Ok("Hakkında bilgisi silindi");
        }
    }
}
