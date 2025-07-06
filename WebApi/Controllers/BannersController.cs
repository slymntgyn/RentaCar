using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommendsHandler createBannerCommendsHandler;
        private readonly GetBannerByIdQueryHandler getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler getBannerQueryHandler;
        private readonly RemoveBannerCommendsHandler removeBannerCommendsHandler;
        private readonly UpdateBannerCommendsHandler updateBannerCommendsHandler;

        public BannersController(CreateBannerCommendsHandler createBannerCommendsHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, RemoveBannerCommendsHandler removeBannerCommendsHandler, UpdateBannerCommendsHandler updateBannerCommendsHandler)
        {
            this.createBannerCommendsHandler = createBannerCommendsHandler;
            this.getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            this.getBannerQueryHandler = getBannerQueryHandler;
            this.removeBannerCommendsHandler = removeBannerCommendsHandler;
            this.updateBannerCommendsHandler = updateBannerCommendsHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetBannerList()
        {
            List<Application.Features.CQRS.Results.BannerResult.GetBannerQueryResult> result = await getBannerQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBannerById(int id)
        {
            Application.Features.CQRS.Results.BannerResult.GetBannerByIdQueryResult? result = await getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            if (result == null)
            {
                return NotFound("Banner not found");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommands request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data");
            }
            await createBannerCommendsHandler.Handle(request);
            return Ok("Banner created successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBanner(int id, UpdateBannerCommands request)
        {
            if (id != request.Id)
            {
                return BadRequest("ID mismatch");
            }
            await updateBannerCommendsHandler.Handle(request);
            return Ok("Banner updated successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await removeBannerCommendsHandler.Handle(new RemoveBannerCommands(id));
            return Ok("Banner removed successfully");

        }
    }
}