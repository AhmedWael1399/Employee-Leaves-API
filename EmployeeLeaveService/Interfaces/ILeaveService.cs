using Models;
using Models.Dtos.LeaveDtos;
using Models.Helpers;

namespace EmployeeLeaveService.Interfaces
{
    public interface ILeaveService
    {
        public List<LeaveDto> GetLeaves();
        public List<LeaveDto> GetFilteredLeaves(QueryObjectLeave query);
        public LeaveDto GetLeaveById(int leaveId);
        public CreateAndUpdateLeaveDto CreateLeave(CreateAndUpdateLeaveDto leaveDto);
        public CreateAndUpdateLeaveDto UpdateLeave(int leaveId, CreateAndUpdateLeaveDto leave);
        public void DeleteLeave(int leaveId);
        public bool LeaveExists(int leaveId);
        public bool LeaveTypeExists(string leaveType);
    }
}
