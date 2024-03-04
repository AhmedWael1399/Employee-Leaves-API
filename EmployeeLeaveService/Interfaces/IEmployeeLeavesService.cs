using Models;
using Models.Dtos.EmployeeDtos;
using Models.Dtos.EmployeeLeavesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveService.Interfaces
{
    public interface IEmployeeLeavesService
    {
        List<EmployeeLeaveDto> GetEmployeeLeaveYears();
        List<LeaveTypeBalanceDto> GetEmployeeLeaveBalances(Guid employeeGuid);
        List<CreateEmployeeLeaveDto> GetAllEmployeesWithLeaves(int page, int pageSize);
    }
}
