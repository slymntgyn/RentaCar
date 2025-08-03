using Application.Features.Mediator.Commands.FooterAdressCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class RemovevFooterAdressCommandHandler : IRequestHandler<RemoveFooterAdressCommand>
    {
        private readonly IRepository<FooterAdress> _repository;

        public RemovevFooterAdressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFooterAdressCommand request, CancellationToken cancellationToken)
        {
            FooterAdress? footerAdress = await _repository.GetByIdAsync(request.Id);
            if (footerAdress != null)
            {
                await _repository.RemoveAsync(request.Id);
            }
            else
            {
                throw new KeyNotFoundException($"Footer address with ID {request.Id} not found.");
            }
        }
    }
}
