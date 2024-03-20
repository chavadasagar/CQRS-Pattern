﻿namespace Domain.Catalog
{
    public class Task
    {
        public int? Id { get; set; }
        public string? TaskDescription { get; set; }
        public int? AssignedTo { get; set; }
        public DateTime? Deadline { get; set; }
        public string? Status { get; set; }
    }
}
