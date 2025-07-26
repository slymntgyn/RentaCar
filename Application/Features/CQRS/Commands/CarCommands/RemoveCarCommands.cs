namespace Application.Features.CQRS.Commands.CarCommands
{
    public class RemoveCarCommands
    {
        public int Id { get; set; }
        public RemoveCarCommands(int id)
        {
            Id = id;
        }
    }
}
