using DatabaseContext;
using EmployeeLeavesRepository.Interfaces;
using EmployeeLeaveUnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Dtos.EmployeeDtos;
using Models.Dtos.EmployeeLeavesDto;
using Models.Helpers;

namespace EmployeeLeavesRepository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeLeaveDbContext employeeLeaveContext;
        public EmployeeRepository(IEmployeeLeaveUow unitOfWork)
        {
            employeeLeaveContext = unitOfWork.GetEmployeeLeaveContext();
        }

        public Employee CreateEmployee(Employee employee)
        {
            employeeLeaveContext.Employees.Add(employee);
            return employee;
        }

        public Employee UpdateEmployee(Guid employeeId, CreateAndUpdateEmployeeDto employeeDto)
        {
            Employee SpecifiedEmployee = employeeLeaveContext.Employees.FirstOrDefault(e => e.EmployeeGuid == employeeId);
            if (SpecifiedEmployee == null) return null;

            SpecifiedEmployee.Name = employeeDto.Name;

            return SpecifiedEmployee;
        }

        public void DeleteEmployee(Guid employeeId)
        {
            var employee = employeeLeaveContext.Employees.FirstOrDefault(e => e.EmployeeGuid == employeeId);
            if (employee != null)
            {
                employeeLeaveContext.Employees.Remove(employee);
            }
        }

        public bool EmployeeExists(Guid employeeId)
        {
            return employeeLeaveContext.Employees.Any(e => e.EmployeeGuid == employeeId);
        }

        public EmployeeDto GetEmployeeById(Guid employeeId)
        {
            EmployeeDto employee = employeeLeaveContext.Employees.Where(employee => employee.EmployeeGuid == employeeId)
             .Select(employee => new EmployeeDto
             {
                 EmployeeGuid = employee.EmployeeGuid,
                 Name = employee.Name,
             }).FirstOrDefault()!;
            return employee;
        }

        public List<EmployeeDto> GetFilteredEmployees(QueryObjectEmployee query)
        {
            IQueryable<Employee> employeesQuery = employeeLeaveContext.Employees;
            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                employeesQuery = employeesQuery.Where(e => e.Name!.Contains(query.Name));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    employeesQuery = query.IsDescending ? employeesQuery.OrderByDescending(e => e.EmployeeGuid) : employeesQuery.OrderBy(e => e.EmployeeGuid);
                }
                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    employeesQuery = query.IsDescending ? employeesQuery.OrderByDescending(e => e.Name) : employeesQuery.OrderBy(e => e.Name);
                }
            }
            List<EmployeeDto> employees = employeesQuery
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(employee => new EmployeeDto
                {
                    EmployeeGuid = employee.EmployeeGuid,
                    Name = employee.Name,

                }).ToList();
            return employees.ToList();
        }

        public List<EmployeeDto> GetEmployees()
        {
            List<EmployeeDto> employees = employeeLeaveContext.Employees
                .Select(employee => new EmployeeDto
                {
                   EmployeeGuid = employee.EmployeeGuid,
                   Name = employee.Name,
                }).ToList();
            return employees;
        }
        /*
        public List<CreateEmployeeLeaveDto> GetEmployeeLeaveTypes()
        {
            List<CreateEmployeeLeaveDto> createdEmployeeLeaves = employeeLeaveContext.Employees.Include(l => l.Leaves)
                .Select(createdEmployeeLeave => new CreateEmployeeLeaveDto
                {
                    EmployeeGuid = createdEmployeeLeave.EmployeeGuid,
                    EmployeeName = createdEmployeeLeave.Name,
                    Leaves = createdEmployeeLeave.Leaves.ToList(),
                    TotalDays = createdEmployeeLeave.Leaves.Balance
                });
            return createdEmployeeLeaves;
        }
        */
    }
}
