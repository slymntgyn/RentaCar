using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Handlers.BrandHandlers;
using Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommendsHandler createBrandCommendsHandler;
        private readonly GetBrandByIdQueryHandler getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler getBrandQueryHandler;
        private readonly RemoveBrandCommendsHandler removeBrandCommendsHandler;
        private readonly UpdateBrandCommendsHandler updateBrandCommendsHandler;

        public BrandsController(CreateBrandCommendsHandler createBrandCommendsHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler, RemoveBrandCommendsHandler removeBrandCommendsHandler, UpdateBrandCommendsHandler updateBrandCommendsHandler)
        {
            this.createBrandCommendsHandler = createBrandCommendsHandler;
            this.getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            this.getBrandQueryHandler = getBrandQueryHandler;
            this.removeBrandCommendsHandler = removeBrandCommendsHandler;
            this.updateBrandCommendsHandler = updateBrandCommendsHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrandList()
        {
            List<Application.Features.CQRS.Results.BrandResult.GetBrandQueryResult> result = await getBrandQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            Application.Features.CQRS.Results.BrandResult.GetBrandByIdQueryResult? result = await getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            if (result == null)
            {
                return NotFound("Brand not found");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommands request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data");
            }
            await createBrandCommendsHandler.Handle(request);
            return Ok("Brand information added successfully");
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, UpdateBrandCommands request)
        {
            if (id != request.Id)
            {
                return BadRequest("ID mismatch");
            }
            await updateBrandCommendsHandler.Handle(request);
            return Ok("Brand information updated successfully");
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await removeBrandCommendsHandler.Handle(new RemoveBrandCommands(id));
            return Ok("Brand information deleted successfully");
        }

    }
}
