using Application.Catalog.Employee;
using Application.Catalog.Employee.DTOs;
using Domain.Catalog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ISender _mediator;

        public EmployeeController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok(await _mediator.Send(new GetAllEmployeRequest()));
        }
    }
}
