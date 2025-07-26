namespace Application.Features.CQRS.Commands.ContactCommands
{
    public class RemoveContactCommands
    {
        public int Id { get; set; }
        public RemoveContactCommands(int id)
        {
            Id = id;
        }

    }
}
