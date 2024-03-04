using Models;
using Models.Dtos.EmployeeDtos;
using Models.Dtos.EmployeeLeavesDto;
using Models.Helpers;

namespace EmployeeLeavesRepository.Interfaces
{
    public interface IEmployeeRepository
    {
        public List<EmployeeDto> GetEmployees();
        public List<EmployeeDto> GetFilteredEmployees(QueryObjectEmployee query);
        public EmployeeDto GetEmployeeById(Guid employeeId);
        public Employee CreateEmployee(Employee employee);
        public Employee UpdateEmployee(Guid employeeId, CreateAndUpdateEmployeeDto employeeDto);
        public void DeleteEmployee(Guid employeeId);
        public bool EmployeeExists (Guid employeeId);
        //public List<CreateEmployeeLeaveDto> GetEmployeeLeaveTypes();
    }
}
