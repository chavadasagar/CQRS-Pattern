using Domain.Catalog;

namespace Application.Common.Persistence
{
    public interface ITodoRepository
    {
        Task<List<Todo>> ListAsync();
    }
}
