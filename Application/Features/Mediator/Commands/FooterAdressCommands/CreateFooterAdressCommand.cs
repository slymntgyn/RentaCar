using MediatR;

namespace Application.Features.Mediator.Commands.FooterAdressCommands
{
    public class CreateFooterAdressCommand : IRequest
    {
        public string? Desciption { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
