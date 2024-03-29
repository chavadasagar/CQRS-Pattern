﻿namespace Application.Catalog.Employee.DTOs
{
    public class EmployeesDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public List<TaskDto>? Tasks { get; set; }
    }
}
