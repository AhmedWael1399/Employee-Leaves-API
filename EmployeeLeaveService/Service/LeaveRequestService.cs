using EmployeeLeaveService.Interfaces;
using EmployeeLeavesRepository.Interfaces;
using EmployeeLeaveUnitOfWork.Interfaces;
using Models;
using Models.Dtos.LeaveRequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveService.Service
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IEmployeeLeaveUow _unitOfWork;
        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository, IEmployeeLeaveUow unitOfWork)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _unitOfWork = unitOfWork;
        }

        public List<LeaveRequestDto> GetLeaveRequests()
        {
            return  _leaveRequestRepository.GetLeaveRequests();
        }

        public LeaveRequest CreateLeaveRequest(LeaveRequestCreateDto leaveRequestDto)
        {
            LeaveRequest leaveRequest =  _leaveRequestRepository.CreateLeaveRequest(leaveRequestDto);
            _unitOfWork.SaveChanges();
            return leaveRequest;
        }
    }
}
