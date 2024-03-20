using Application.Catalog.Employee.DTOs;
using Application.Common.Persistence;
using Mapster;
using MediatR;

namespace Application.Catalog.Employee
{
    public class GetAllEmployeRequest:IRequest<IEnumerable<EmployeesDto>>
    {

    }

    public class GetAllEmployeRequestHandler : IRequestHandler<GetAllEmployeRequest, IEnumerable<EmployeesDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeRequestHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeesDto>> Handle(GetAllEmployeRequest request, CancellationToken cancellationToken)
        {
            return (await _employeeRepository.ListAsync()).Adapt<IEnumerable<EmployeesDto>>();
        }
    }

}
