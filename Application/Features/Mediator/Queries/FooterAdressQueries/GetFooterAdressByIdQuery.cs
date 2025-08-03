using Application.Features.Mediator.Results.FooterAdressResult;
using MediatR;

namespace Application.Features.Mediator.Queries.FooterAdressQueries
{
    public class GetFooterAdressByIdQuery : IRequest<GetFooterAdressByIdQueryResult>
    {
        public int Id { get; set; }
        public GetFooterAdressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
