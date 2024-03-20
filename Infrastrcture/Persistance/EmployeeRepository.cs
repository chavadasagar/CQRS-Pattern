using Application.Catalog.Employee.DTOs;
using Application.Common.Persistence;
using Dapper;
using Domain.Catalog;
using Infrastrcture.Persistance.Context;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                return await connection.QueryAsync<Employee, List<Domain.Catalog.Task>, Employee>(("select * from employee e inner join task t on t.id = e.id"),
                    map: (employee, task) =>{
                        employee.Tasks = task;
                        return employee;
                },
                splitOn: "Department"
                );
            }
        }
    }
}
