﻿namespace Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public string? Model { get; set; }
        public string? CoverImageUrl { get; set; }
        public int? Km { get; set; }
        public string? Transmission { get; set; }
        public byte? Seat { get; set; }
        public byte? Lugage { get; set; }
        public string? Fuel { get; set; }
        public string? BigImageUrl { get; set; }
        public List<CarFeature>? CarFeatures { get; set; }
        public List<CarDescription>? CarDescriptions { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}
