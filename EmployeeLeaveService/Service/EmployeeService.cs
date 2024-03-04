using EmployeeLeaveService.Interfaces;
using EmployeeLeavesRepository.Interfaces;
using EmployeeLeavesRepository.Repository;
using EmployeeLeaveUnitOfWork.Interfaces;
using Models;
using Models.Dtos.EmployeeDtos;
using Models.Dtos.LeaveDtos;
using Models.Dtos.YearDtos;
using Models.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeLeaveService.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepostiory;
        private readonly ILeaveRepository _leaveRepository;
        private readonly IYearRepository _yearRepository;
        private readonly IEmployeeLeaveRepository _employeeLeaveRepository;
        private readonly IEmployeeLeaveUow _unitOfWork;
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeLeaveUow unitOfWork, ILeaveRepository leaveRepository, IYearRepository yearRepository, IEmployeeLeaveRepository employeeLeaveRepository)
        {
            _employeeRepostiory = employeeRepository;
            _leaveRepository = leaveRepository;
            _yearRepository = yearRepository;
            _unitOfWork = unitOfWork;
            _employeeLeaveRepository = employeeLeaveRepository;
        }

        public void CreateEmployeeLeaves(Employee employee)
        {
            employee.EmployeeGuid = Guid.NewGuid();
            int yearValue = DateTime.Now.Year;

            List<LeaveDto> leaves = _leaveRepository.GetLeaves().Where(leave => leave.IsDefault).ToList();
            //List<LeaveDto> leaves = _leaveRepository.GetLeaves();
            YearDto year = _yearRepository.GetYearByValue(yearValue);
            List<EmployeeLeave> employeeLeaves = new List<EmployeeLeave>();

            foreach (LeaveDto leave in leaves)
                {
                    EmployeeLeave employeeLeave = new EmployeeLeave
                    {
                        EmployeeGuid = employee.EmployeeGuid,
                        LeaveId = leave.Id,
                        YearId = year.Id,
                        Balance = leave.DefaultDays

                    };
                    employeeLeaves.Add(employeeLeave);
            }
            _employeeLeaveRepository.AddEmployeeLeaves(employeeLeaves);
            _employeeRepostiory.CreateEmployee(employee);
            _unitOfWork.SaveChanges();
        }

        public void DeleteEmployee(Guid employeeId)
        {
            _employeeRepostiory.DeleteEmployee(employeeId);
            _unitOfWork.SaveChanges();
        }

        public bool EmployeeExists(Guid employeeId)
        {
            return _employeeRepostiory.EmployeeExists(employeeId);
        }

        public EmployeeDto GetEmployeeById(Guid employeeId)
        {
            return _employeeRepostiory.GetEmployeeById(employeeId);
        }

        public List<EmployeeDto> GetEmployees()
        {
            return _employeeRepostiory.GetEmployees();
        }

        public List<EmployeeDto> GetFilteredEmployees(QueryObjectEmployee query)
        {
            return _employeeRepostiory.GetFilteredEmployees(query);
        }

        public CreateAndUpdateEmployeeDto UpdateEmployee(Guid employeeId, CreateAndUpdateEmployeeDto employee)
        {
            _employeeRepostiory.UpdateEmployee(employeeId, employee);
            _unitOfWork.SaveChanges();
            return employee;
        }
    }
}
