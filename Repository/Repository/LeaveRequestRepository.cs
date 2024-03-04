using DatabaseContext;
using EmployeeLeavesRepository.Interfaces;
using EmployeeLeaveUnitOfWork.Interfaces;
using Models;
using Models.Dtos.LeaveRequestDtos;

namespace EmployeeLeavesRepository.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly EmployeeLeaveDbContext employeeLeaveContext;
        public LeaveRequestRepository(IEmployeeLeaveUow unitOfWork)
        {
            employeeLeaveContext = unitOfWork.GetEmployeeLeaveContext();
        }

        public List<LeaveRequestDto> GetLeaveRequests()
        {
            List<LeaveRequestDto> leaveRequests = employeeLeaveContext.LeaveRequests
                .Select(leaveRequest => new LeaveRequestDto
                {
                    Id = leaveRequest.Id,
                    EmployeeGuid = leaveRequest.EmployeeGuid,
                    LeaveId = leaveRequest.LeaveId,
                    YearId = leaveRequest.YearId,
                    FromDate = leaveRequest.FromDate,
                    ToDate = leaveRequest.ToDate,
                    Days = leaveRequest.Days,
                    Approved = leaveRequest.Approved
                }).ToList();
            return leaveRequests;
        }

        public LeaveRequest CreateLeaveRequest(LeaveRequestCreateDto leaveRequestDto)
        {

            LeaveRequest existingLeaveRequest = employeeLeaveContext.LeaveRequests
                                                .FirstOrDefault(lr => lr.EmployeeGuid == leaveRequestDto.EmployeeGuid
                                                 && lr.LeaveId == leaveRequestDto.LeaveId
                                                 && leaveRequestDto.FromDate == lr.FromDate
                                                 && leaveRequestDto.ToDate == lr.ToDate);

            if (existingLeaveRequest != null)
            {
                existingLeaveRequest.EmployeeGuid = leaveRequestDto.EmployeeGuid;
                existingLeaveRequest.LeaveId = leaveRequestDto.LeaveId;
                existingLeaveRequest.YearId = leaveRequestDto.YearId;
                existingLeaveRequest.FromDate = leaveRequestDto.FromDate;
                existingLeaveRequest.ToDate = leaveRequestDto.ToDate;
                existingLeaveRequest.Days = leaveRequestDto.Days;
                existingLeaveRequest.Approved = leaveRequestDto.Approved;

                if (leaveRequestDto.Approved == true)
                {
                    employeeLeaveContext.LeaveRequests.Update(existingLeaveRequest);
                    return existingLeaveRequest;
                }
                else
                {
                    return existingLeaveRequest;
                }
            }

                bool leaveTypeNotRegistered = employeeLeaveContext.EmployeesLeaves
                    .Any(el => el.EmployeeGuid == leaveRequestDto.EmployeeGuid && el.LeaveId == leaveRequestDto.LeaveId);

                Leave leave = employeeLeaveContext.Leaves.FirstOrDefault(l => l.Id == leaveRequestDto.LeaveId)!;

                if (!leaveTypeNotRegistered)
                {
                    EmployeeLeave newEmployeeLeave = new EmployeeLeave
                    {
                        EmployeeGuid = leaveRequestDto.EmployeeGuid,
                        LeaveId = leaveRequestDto.LeaveId,
                        YearId = leaveRequestDto.YearId,
                        Balance = leave.DefaultDays
                    };
                    employeeLeaveContext.EmployeesLeaves.Add(newEmployeeLeave);
                }

                LeaveRequest newLeaveRequest = new LeaveRequest
                {
                    EmployeeGuid = leaveRequestDto.EmployeeGuid,
                    LeaveId = leaveRequestDto.LeaveId,
                    YearId = leaveRequestDto.YearId,
                    FromDate = leaveRequestDto.FromDate,
                    ToDate = leaveRequestDto.ToDate,
                    Days = leaveRequestDto.Days,
                    Approved = leaveRequestDto.Approved
                };

                employeeLeaveContext.LeaveRequests.Add(newLeaveRequest);
                return newLeaveRequest;
        }
    }
}
