using Application.Catalog.Employee;
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

        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok(_mediator.Send(new GetAllEmployeRequest()));
        }
    }
}
