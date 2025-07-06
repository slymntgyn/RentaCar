namespace Application.Features.CQRS.Commands.BrandCommands
{
    public class RemoveBrandCommands
    {
        public int id { get; set; }
        public RemoveBrandCommands(int id)
        {
            this.id = id;
        }

    }
}
