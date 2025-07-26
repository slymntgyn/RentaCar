namespace Application.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommands
    {
        public int Id { get; set; }
        public RemoveCategoryCommands(int id)
        {
            Id = id;
        }
    }
}
