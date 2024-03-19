using Domain.Catalog;

namespace Application.Common.Persistence
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> ListAsync();

    }
}
