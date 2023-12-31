﻿using Portal.Domain.Entities.Common;

namespace Portal.Domain.Entities
{
    public class Etkinlik : BaseEntity
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public DateTime start { get; set; }
        public string? image { get; set; }
        public string? Tekrar { get; set; }
        public int? TekrarNum { get; set; } 
        public bool allDay { get; set; } = true;

    }
}
