namespace Application.Features.Mediator.Results.ServicesResult
{
    public class GetServicesByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal IconUrl { get; set; }
    }
}
