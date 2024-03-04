using Models;
using Models.Dtos.EmployeeDtos;
using Models.Dtos.EmployeeLeavesDto;

namespace EmployeeLeavesRepository.Interfaces
{
    public interface IEmployeeLeaveRepository
    {
        List<EmployeeLeaveDto> GetEmployeeLeaves();
        public void AddEmployeeLeaves(List<EmployeeLeave> employeeLeaves);
        List<LeaveTypeBalanceDto> GetLeaveBalances(Guid employeeGuid);
        List<CreateEmployeeLeaveDto> GetAllEmployeesWithLeaves(int page, int pageSize);
    }
}
