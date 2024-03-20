namespace Application.Catalog.Employee.DTOs
{
    public class TaskDto
    {
        public int? Id { get; set; }
        public string? TaskDescription { get; set; }
        public Guid? AssignedTo { get; set; }
        public DateTime? Deadline { get; set; }
        public string? Status { get; set; }
    }
}
