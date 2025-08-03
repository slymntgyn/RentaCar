using Application.Features.Mediator.Queries.FooterAdressQueries;
using Application.Features.Mediator.Results.FooterAdressResult;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class GetFooterAdressByIdQueryHandler : IRequestHandler<GetFooterAdressByIdQuery, GetFooterAdressByIdQueryResult>
    {
        private readonly IRepository<FooterAdress> _repository;
        public GetFooterAdressByIdQueryHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAdressByIdQueryResult> Handle(GetFooterAdressByIdQuery request, CancellationToken cancellationToken)
        {
            FooterAdress? footerAdress = await _repository.GetByIdAsync(request.Id);
            if (footerAdress == null) { }

            return new GetFooterAdressByIdQueryResult
            {
                Id = footerAdress?.Id ?? 0,
                Desciption = footerAdress?.Desciption ?? string.Empty,
                Adress = footerAdress?.Adress ?? string.Empty,
                Phone = footerAdress?.Phone ?? string.Empty,
                Email = footerAdress?.Email ?? string.Empty
            };
        }
    }

}
