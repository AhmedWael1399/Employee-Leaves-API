using EmployeeLeavesRepository.Repository;
using Models;
using Models.Dtos.LeaveRequestDtos;

namespace EmployeeLeavesRepository.Interfaces
{
    public interface ILeaveRequestRepository
    {
        List<LeaveRequestDto> GetLeaveRequests();
        LeaveRequest CreateLeaveRequest(LeaveRequestCreateDto leaveRequestDto);
    }
}
