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

                var employeDictionary = new Dictionary<int, Employee>();

                string Query = "select e.*,t.* from employee e join task t on e.Id = t.AssignedTo";

                return (await connection.QueryAsync<Employee, Domain.Catalog.Task, Employee>((Query),
                    (emp, task) =>
                    {
                        if (!employeDictionary.TryGetValue(emp.Id, out var employee))
                        {
                            employee = emp;
                            employeDictionary.Add(emp.Id, employee);
                        }
                        employee.Tasks = employee.Tasks ?? new List<Domain.Catalog.Task>();
                        employee.Tasks.Add(task);
                        return employee;
                    },
                splitOn: "AssignedTo"
                )).Distinct();
            }
        }
    }
}
