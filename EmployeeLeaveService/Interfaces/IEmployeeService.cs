using Models;
using Models.Dtos.EmployeeDtos;
using Models.Helpers;

namespace EmployeeLeaveService.Interfaces
{
    public interface IEmployeeService
    {
        public List<EmployeeDto> GetEmployees();
        public List<EmployeeDto> GetFilteredEmployees(QueryObjectEmployee query);
        public EmployeeDto GetEmployeeById(Guid employeeId);
        public void CreateEmployeeLeaves(Employee employee);
        public CreateAndUpdateEmployeeDto UpdateEmployee(Guid employeeId, CreateAndUpdateEmployeeDto employee);
        public void DeleteEmployee(Guid employeeId);
        public bool EmployeeExists(Guid employeeId);
    }
}
