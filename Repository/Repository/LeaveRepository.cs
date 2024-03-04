using DatabaseContext;
using DbFactory.Interfaces;
using EmployeeLeavesRepository.Interfaces;
using EmployeeLeaveUnitOfWork.Interfaces;
using Models;
using Models.Dtos.LeaveDtos;
using Models.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeLeavesRepository.Repository
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly EmployeeLeaveDbContext employeeLeaveContext;
        public LeaveRepository(IEmployeeLeaveUow unitOfWork)
        {
            employeeLeaveContext = unitOfWork.GetEmployeeLeaveContext();
        }
        public Leave CreateLeave (CreateAndUpdateLeaveDto leaveDto)
        {
            Leave leave = new ()
            {
                Type = leaveDto.Type,
                DefaultDays = leaveDto.DefaultDays,
                IsDefault = leaveDto.IsDefault
            };
            employeeLeaveContext.Add(leave);
            return leave;
        }

        public void DeleteLeave(int leaveId)
        {
            var leave = employeeLeaveContext.Leaves.FirstOrDefault(l => l.Id == leaveId);
            if (leave != null)
            {
                employeeLeaveContext.Leaves.Remove(leave);
            }
        }

        public LeaveDto GetLeaveById(int leaveId)
        {
            LeaveDto leave = employeeLeaveContext.Leaves.Where(leave => leave.Id == leaveId)
                .Select(leave => new LeaveDto
                {
                    Id = leave.Id,
                    Type = leave.Type,
                    DefaultDays = leave.DefaultDays,
                    IsDefault = leave.IsDefault,
                }).FirstOrDefault()!;
            return leave;
        }

        public List<LeaveDto> GetFilteredLeaves(QueryObjectLeave query)
        {
            IQueryable<Leave> leavesQuery = employeeLeaveContext.Leaves;

            if (query.StartDefaultDays.HasValue)
            {
                leavesQuery = leavesQuery.Where(l => l.DefaultDays >= query.StartDefaultDays);
            }
            if (query.EndDefaultDays.HasValue)
            {
                leavesQuery = leavesQuery.Where(l => l.DefaultDays <= query.EndDefaultDays);
            }
            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                leavesQuery = leavesQuery.Where(l => l.Type!.Contains(query.Name));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    leavesQuery = query.IsDescending ? leavesQuery.OrderByDescending(l => l.Id) : leavesQuery.OrderBy(l => l.Id);
                }
                else if (query.SortBy.Equals("Type", StringComparison.OrdinalIgnoreCase))
                {
                    leavesQuery = query.IsDescending ? leavesQuery.OrderByDescending(l => l.Type) : leavesQuery.OrderBy(l => l.Type);
                }
            }
            List<LeaveDto> leaves = leavesQuery
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(leave => new LeaveDto
                {
                    Id = leave.Id,
                    Type = leave.Type,
                    DefaultDays = leave.DefaultDays,
                    IsDefault = leave.IsDefault,
                }).ToList();

            return leaves;
        }

        public List<LeaveDto> GetLeaves()
        {
            List<LeaveDto> leaves = employeeLeaveContext.Leaves
                .Select(leave => new LeaveDto
                {
                    Id = leave.Id,
                    Type = leave.Type,
                    DefaultDays = leave.DefaultDays,
                    IsDefault = leave.IsDefault,
                }).ToList();

            return leaves;
        }

        public bool LeaveExists(int leaveId)
        {
            return employeeLeaveContext.Leaves.Any(l => l.Id == leaveId);
        }

        public Leave UpdateLeave(int leaveId, CreateAndUpdateLeaveDto leaveDto)
        { 
            Leave specifiedLeave = employeeLeaveContext.Leaves.FirstOrDefault(l => l.Id == leaveId);
            if (specifiedLeave == null) return null;
            
            specifiedLeave.Type = leaveDto.Type;
            specifiedLeave.DefaultDays = leaveDto.DefaultDays;
            specifiedLeave.IsDefault = leaveDto.IsDefault;
            
            return specifiedLeave;
            
        }
        public bool leaveTypeExists(string leaveType)
        {
            return employeeLeaveContext.Leaves.Any(l => l.Type == leaveType);
        }
    }
}
