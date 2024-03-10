using Application.Catalog.Todo.DTOs;
using Application.Catalog.Todos;
using Application.Common.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ISender _mediator;

        public TodoController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("todos")]
        public async Task<IActionResult> GetAllTodo()
        {
            try
            {
                var todos = await _mediator.Send(new GetAllTodoQuery());
                return Ok(await Result<List<TodoDto>>.SuccessAsync(todos,"Todos"));
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
