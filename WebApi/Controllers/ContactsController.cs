using Application.Features.CQRS.Commands.ContactCommands;
using Application.Features.CQRS.Handlers.ContactHandlers;
using Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandsHandler createContactCommandsHandler;
        private readonly GetContactByIdQueryHandler getContactByIdQueryHandler;
        private readonly GetContactQueryHandler getContactQueryHandler;
        private readonly RemoveContactCommandsHandler removeContactCommandsHandler;
        private readonly UpdateContactCommandsHandler updateContactCommandsHandler;

        public ContactsController(CreateContactCommandsHandler createContactCommandsHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler, RemoveContactCommandsHandler removeContactCommandsHandler, UpdateContactCommandsHandler updateContactCommandsHandler)
        {
            this.createContactCommandsHandler = createContactCommandsHandler;
            this.getContactByIdQueryHandler = getContactByIdQueryHandler;
            this.getContactQueryHandler = getContactQueryHandler;
            this.removeContactCommandsHandler = removeContactCommandsHandler;
            this.updateContactCommandsHandler = updateContactCommandsHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetContactList()
        {
            List<Application.Features.CQRS.Results.ContactResult.GetContactQueryResult> result = await getContactQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            Application.Features.CQRS.Results.ContactResult.GetByIdContactQueryResult? result = await getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            if (result == null)
            {
                return NotFound("Contact not found");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommands request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data");
            }
            await createContactCommandsHandler.Handle(request);
            return Ok("Contact information added successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, UpdateContactCommands request)
        {
            if (id != request.Id)
            {
                return BadRequest("ID mismatch");
            }
            await updateContactCommandsHandler.Handle(request);
            return Ok("Contact information updated successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await removeContactCommandsHandler.Handle(new RemoveContactCommands(id));
            return Ok("Contact information deleted successfully");
        }
    }
}