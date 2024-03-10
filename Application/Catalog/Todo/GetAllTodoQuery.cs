using Application.Catalog.Todo.DTOs;
using Application.Common.Persistence;
using Mapster;
using MediatR;

namespace Application.Catalog.Todos
{
    public class GetAllTodoQuery : IRequest<List<TodoDto>>
    {
    }

    public class GetAllTodoQueryHandler : IRequestHandler<GetAllTodoQuery, List<TodoDto>>
    {
        private readonly ITodoRepository _todoRepository;

        public GetAllTodoQueryHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<TodoDto>> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
        {
            var todos = await _todoRepository.ListAsync();
            return todos.Adapt<List<TodoDto>>();

        }
    }
}
