using MediatR;

namespace Application.Features.Mediator.Commands.FooterAdressCommands
{
    public class UpdateFooterAdressCommand : IRequest
    {
        public int Id { get; set; }
        public string? Desciption { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
