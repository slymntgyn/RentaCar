﻿namespace Application.Features.CQRS.Results.ContactResult
{
    public class GetContactQueryResult
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime SendDate { get; set; } = DateTime.UtcNow;
    }
}
