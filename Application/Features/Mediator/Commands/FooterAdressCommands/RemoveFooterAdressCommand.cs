using MediatR;

namespace Application.Features.Mediator.Commands.FooterAdressCommands
{
    public class RemoveFooterAdressCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveFooterAdressCommand(int id)
        {
            Id = id;
        }
    }
}
