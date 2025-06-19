namespace Domain.Entities
{
    public class Testimonial
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Command { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
