using Domain.Entities;

namespace Application.Features.CQRS.Commands.BrandCommands
{
    public class UpdateBrandCommands
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
