using Application.Features.Mediator.Commands.FooterAdressCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class UpdateFooterAdressCommandHandler : IRequestHandler<UpdateFooterAdressCommand>
    {
        private readonly IRepository<FooterAdress> _repository;

        public UpdateFooterAdressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            FooterAdress? footerAdress = await _repository.GetByIdAsync(request.Id);
            if (footerAdress != null)
            {
                footerAdress.Desciption = request.Desciption;
                footerAdress.Adress = request.Adress;
                footerAdress.Phone = request.Phone;
                footerAdress.Email = request.Email;
                await _repository.UpdateAsync(footerAdress);
            }
            else
            {
                throw new KeyNotFoundException($"Footer address with ID {request.Id} not found.");
            }

        }
    }
}
