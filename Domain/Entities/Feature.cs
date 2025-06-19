﻿namespace Domain.Entities
{
    public class Feature
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<CarFeature>? CarFeatures { get; set; }
    }
}
