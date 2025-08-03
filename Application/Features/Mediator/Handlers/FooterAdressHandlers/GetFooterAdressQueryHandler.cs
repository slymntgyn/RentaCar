using Application.Features.Mediator.Queries.FooterAdressQueries;
using Application.Features.Mediator.Results.FooterAdressResult;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class GetFooterAdressQueryHandler : IRequestHandler<GetFooterAdressQuery, List<GetFooterAdressQueryResult>>
    {
        private readonly IRepository<FooterAdress> _repository;

        public GetFooterAdressQueryHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAdressQueryResult>> Handle(GetFooterAdressQuery request, CancellationToken cancellationToken)
        {
            List<FooterAdress> footerAdresses = await _repository.GetAllAsync();

            return footerAdresses.Select(feature => new GetFooterAdressQueryResult
            {
                Id = feature.Id,
                Desciption = feature.Desciption,
                Adress = feature.Adress,
                Phone = feature.Phone,
                Email = feature.Email
            }).ToList();
        }

    }

}
