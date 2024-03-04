using DatabaseContext;
using EmployeeLeavesRepository.Interfaces;
using EmployeeLeaveUnitOfWork.Interfaces;
using Models;
using Models.Dtos.EmployeeLeavesDto;
using Models.Dtos.LeaveDtos;

namespace EmployeeLeavesRepository.Repository
{
    public class EmployeeLeaveRepository : IEmployeeLeaveRepository
    {
        private readonly EmployeeLeaveDbContext employeeLeaveContext;
        public EmployeeLeaveRepository(IEmployeeLeaveUow unitOfWork)
        {
            employeeLeaveContext = unitOfWork.GetEmployeeLeaveContext();
        }

        public List<EmployeeLeaveDto> GetEmployeeLeaves()
        {

            List<EmployeeLeaveDto> employeeLeaves = employeeLeaveContext.EmployeesLeaves
                .Select(employeeLeave => new EmployeeLeaveDto
                {
                    Id = employeeLeave.Id,
                    EmployeeGuid = employeeLeave.EmployeeGuid,
                    LeaveId = employeeLeave.LeaveId,
                    YearId = employeeLeave.YearId,
                    Balance = employeeLeave.Balance
                }).ToList();
            return employeeLeaves;
        }

        public void AddEmployeeLeaves(List<EmployeeLeave> employeeLeaves)
        {
            employeeLeaveContext.EmployeesLeaves.AddRange(employeeLeaves);
        }

        public List<LeaveTypeBalanceDto> GetLeaveBalances(Guid employeeGuid)
        {
            var query = from l in employeeLeaveContext.Leaves
                        from el in l.EmployeeLeaves!.Where(el => el.EmployeeGuid == employeeGuid).DefaultIfEmpty()
                        select new { l, el };
            List<LeaveTypeBalanceDto> leaveBalances = query
                .AsEnumerable()
                .GroupBy(x => x.l.Type)
                .Select(g => new LeaveTypeBalanceDto
                {
                    LeaveType = g.Key,
                    Balance = g.Sum(x => x.el != null ? x.el.Balance : 0)
                })
                .ToList();
            return leaveBalances;
        }


        public List<CreateEmployeeLeaveDto> GetAllEmployeesWithLeaves(int page, int pageSize)
        {
            var query = (from e in employeeLeaveContext.Employees
                         join elg in employeeLeaveContext.EmployeesLeaves on e.EmployeeGuid equals elg.EmployeeGuid into elgJoin
                         from elg in elgJoin.DefaultIfEmpty()
                         join lg in employeeLeaveContext.Leaves on elg.LeaveId equals lg.Id into lgJoin
                         from lg in lgJoin.DefaultIfEmpty()
                         join lrg in employeeLeaveContext.LeaveRequests.Where(lr => lr.Approved == true) on new { elg.EmployeeGuid, elg.LeaveId } equals new { lrg.EmployeeGuid, lrg.LeaveId } into lrgJoin
                         from lrg in lrgJoin.DefaultIfEmpty()
                         group new { e, elg, lg, lrg } by new { e.EmployeeGuid, e.Name, lg.Type, elg.Balance } into g
                         orderby g.Key.EmployeeGuid, g.Key.Name
                         select new
                         {
                             EmployeeGuid = g.Key.EmployeeGuid,
                             EmployeeName = g.Key.Name,
                             LeaveType = g.Key.Type,
                             DefaultDays = g.Key.Balance,
                             LeaveDays = g.Sum(x => x.lrg != null ? x.lrg.Days : 0),
                             TotalDays = g.Sum(x => x.elg != null ? x.elg.Balance : 0)
                         } into result
                         group result by new { result.EmployeeGuid, result.EmployeeName } into g
                         select new CreateEmployeeLeaveDto
                         {
                             EmployeeGuid = g.Key.EmployeeGuid,
                             EmployeeName = g.Key.EmployeeName,
                             Leaves = g.Select(l => new LeaveEmployeeLeaveDto
                             {
                                 LeaveType = l.LeaveType,
                                 LeaveDays = l.LeaveDays,
                                 DefaultDays = l.DefaultDays
                             }).ToList(),
                             LeaveDays = g.Sum(l => l.LeaveDays),
                             TotalDays = g.Sum(l => l.DefaultDays)
                         }).Skip((page - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();

            return query;
        }

    }
}
