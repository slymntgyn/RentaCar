namespace Application.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommands
    {
        public int Id { get; set; }
        public RemoveBannerCommands(int id)
        {
            Id = id;
        }
    }
}
