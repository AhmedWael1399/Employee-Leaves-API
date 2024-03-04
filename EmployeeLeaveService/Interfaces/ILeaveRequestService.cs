using Models;
using Models.Dtos.LeaveRequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveService.Interfaces
{
    public interface ILeaveRequestService
    {
        List<LeaveRequestDto> GetLeaveRequests();
        LeaveRequest CreateLeaveRequest(LeaveRequestCreateDto leaveRequestDto);
    }
}
