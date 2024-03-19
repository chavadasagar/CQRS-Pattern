using Application.Common.Persistence;
using Dapper;
using Domain.Catalog;
using Infrastrcture.Persistance.Context;

namespace Infrastrcture.Persistance
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CQRSPatternContext _cQRSPatternContext;
        public EmployeeRepository(CQRSPatternContext cQRSPatternContext)
        {
            _cQRSPatternContext = cQRSPatternContext;
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            using (var connection = _cQRSPatternContext.CreateConnection())
            {
                connection.Open();
                return await connection.QueryAsync<Employee>("select * from Employee", new DynamicParameters());
            }
        }
    }
}
