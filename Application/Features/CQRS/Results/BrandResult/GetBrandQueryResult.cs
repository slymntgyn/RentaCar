using Domain.Entities;

namespace Application.Features.CQRS.Results.BrandResult
{
    public class GetBrandQueryResult
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
