using Domain.Entities;

namespace Application.Features.CQRS.Commands.BrandCommands
{
    public class CreateBrandCommands
    {
        public string? Name { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
