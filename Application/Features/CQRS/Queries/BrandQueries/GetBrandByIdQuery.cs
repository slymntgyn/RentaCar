namespace Application.Features.CQRS.Queries.BrandQueries
{
    public class GetBrandByIdQuery
    {
        public int id { get; set; }
        public GetBrandByIdQuery(int id)
        {
            this.id = id;
        }

    }
}
