namespace Domain.Catalog
{
    internal class Task
    {
        public Guid? Id { get; set; }
        public string? TaskDescription { get; set; }
        public Guid? AssignedTo { get; set; }
        public DateTime? Deadline { get; set; }
        public string? Status { get; set; }
    }
}
