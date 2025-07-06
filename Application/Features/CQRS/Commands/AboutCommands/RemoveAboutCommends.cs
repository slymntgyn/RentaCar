namespace Application.Features.CQRS.Commands.AboutCommands
{
    public class RemoveAboutCommends
    {
        public int Id { get; set; }
        public RemoveAboutCommends(int id)
        {
            Id = id;
        }

    }
}
