using EmployeeLeaveService.Interfaces;
using EmployeeLeavesRepository.Interfaces;
using EmployeeLeaveUnitOfWork.Interfaces;
using Models;
using Models.Dtos.EmployeeLeavesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveService.Service
{
    public class EmployeeLeavesService : IEmployeeLeavesService
    {
        private readonly IEmployeeLeaveRepository _employeeLeaveRepository;
        private readonly ILeaveRepository _leaveRepository;
        private readonly IEmployeeLeaveUow _unitOfWork;
        public EmployeeLeavesService(IEmployeeLeaveRepository employeeLeaveYearRepository, ILeaveRepository leaveRepository, IEmployeeLeaveUow unitOfWork)
        {
            _employeeLeaveRepository = employeeLeaveYearRepository;
            _leaveRepository = leaveRepository;
            _unitOfWork = unitOfWork;
        }

        public  List<EmployeeLeaveDto> GetEmployeeLeaveYears()
        {
            return _employeeLeaveRepository.GetEmployeeLeaves();
        }
        
        public List<LeaveTypeBalanceDto> GetEmployeeLeaveBalances(Guid employeeGuid)
        {
            return _employeeLeaveRepository.GetLeaveBalances(employeeGuid);    
        }
        
        public List<CreateEmployeeLeaveDto> GetAllEmployeesWithLeaves(int page, int pageSize)
        {
           return _employeeLeaveRepository.GetAllEmployeesWithLeaves(page, pageSize);
        }
        
    }
}
