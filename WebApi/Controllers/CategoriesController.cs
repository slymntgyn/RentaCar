using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Handlers.CategoryHandlers;
using Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CreateCategoryCommandsHandler createCategoryCommandsHandler;
        private readonly GetCategoryByIdQueryHandler getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler getCategoryQueryHandler;
        private readonly RemoveCategoryCommendsHandler removeCategoryCommandsHandler;
        private readonly UpdateCategoryCommendsHandler updateCategoryCommandsHandler;

        public CategoriesController(CreateCategoryCommandsHandler createCategoryCommandsHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, RemoveCategoryCommendsHandler removeCategoryCommandsHandler, UpdateCategoryCommendsHandler updateCategoryCommandsHandler)
        {
            this.createCategoryCommandsHandler = createCategoryCommandsHandler;
            this.getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            this.getCategoryQueryHandler = getCategoryQueryHandler;
            this.removeCategoryCommandsHandler = removeCategoryCommandsHandler;
            this.updateCategoryCommandsHandler = updateCategoryCommandsHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            List<Application.Features.CQRS.Results.CategoryResult.GetCategoryQueryResult> result = await getCategoryQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            Application.Features.CQRS.Results.CategoryResult.GetByIdCategoryQueryResult? result = await getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            if (result == null)
            {
                return NotFound("Category not found");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommands request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data");
            }
            await createCategoryCommandsHandler.Handle(request);
            return Ok("Category created successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryCommands request)
        {
            if (id != request.Id)
            {
                return BadRequest("ID mismatch");
            }
            await updateCategoryCommandsHandler.Handle(request);
            return Ok("Category updated successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await removeCategoryCommandsHandler.Handle(new RemoveCategoryCommands(id));
            return Ok("Category deleted successfully");
        }
    }
}
