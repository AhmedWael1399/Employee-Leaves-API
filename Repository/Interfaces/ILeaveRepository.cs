using Models;
using Models.Dtos.LeaveDtos;
using Models.Helpers;

namespace EmployeeLeavesRepository.Interfaces
{
    public interface ILeaveRepository
    {
        public List<LeaveDto> GetLeaves();
        public List<LeaveDto> GetFilteredLeaves(QueryObjectLeave query);
        public LeaveDto GetLeaveById(int leaveId);
        public Leave CreateLeave(CreateAndUpdateLeaveDto leave);
        public Leave UpdateLeave(int leaveId, CreateAndUpdateLeaveDto leave);
        public void DeleteLeave(int leaveId);
        public bool LeaveExists(int leaveId);
        public bool leaveTypeExists(string leaveType);
    }
}
