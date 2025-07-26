using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResult;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandsHandler createCarCommendsHandler;
        private readonly GetCarByIdQueryHandler getCarByIdQueryHandler;
        private readonly GetCarQueryHandler getCarQueryHandler;
        private readonly RemoveCarCommendsHandler removeCarCommendsHandler;
        private readonly UpdateCarCommendsHandler updateCarCommendsHandler;
        private readonly GetCarWithBrandQueryHandler getCarWithBrandQueryHandler;

        public CarsController(CreateCarCommandsHandler createCarCommendsHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, RemoveCarCommendsHandler removeCarCommendsHandler, UpdateCarCommendsHandler updateCarCommendsHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            this.createCarCommendsHandler = createCarCommendsHandler;
            this.getCarByIdQueryHandler = getCarByIdQueryHandler;
            this.getCarQueryHandler = getCarQueryHandler;
            this.removeCarCommendsHandler = removeCarCommendsHandler;
            this.updateCarCommendsHandler = updateCarCommendsHandler;
            this.getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarList()
        {
            List<GetCarQueryResult> result = await getCarQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            GetCarByIdQueryResult? result = await getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            if (result == null)
            {
                return NotFound("Car not found");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommands request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data");
            }
            await createCarCommendsHandler.Handle(request);
            return Ok("Car created successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, UpdateCarCommands request)
        {
            if (id != request.Id)
            {
                return BadRequest("ID mismatch");
            }
            await updateCarCommendsHandler.Handle(request);
            return Ok("Car updated successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await removeCarCommendsHandler.Handle(new RemoveCarCommands(id));
            return Ok("Car removed successfully");
        }
        [HttpGet("GetCarWithBrand")]
        public IActionResult GetCarWithBrand()
        {
            Task<List<GetCarWithBrandQueryResult>> result = getCarWithBrandQueryHandler.Handle();
            return Ok(result);


        }
    }
}
