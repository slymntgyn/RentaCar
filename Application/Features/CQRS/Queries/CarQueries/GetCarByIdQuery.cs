namespace Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarByIdQuery
    {
        public int id { get; set; }
        public GetCarByIdQuery(int id)
        {
            this.id = id;
        }
    }
}