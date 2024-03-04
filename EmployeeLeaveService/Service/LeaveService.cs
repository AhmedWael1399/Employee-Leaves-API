using EmployeeLeaveService.Interfaces;
using EmployeeLeavesRepository.Interfaces;
using EmployeeLeavesRepository.Repository;
using EmployeeLeaveUnitOfWork.Interfaces;
using Models;
using Models.Dtos.LeaveDtos;
using Models.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeLeaveService.Service
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepository _leaveRepository;
        private readonly IEmployeeLeaveUow _unitOfWork;
        public LeaveService(ILeaveRepository leaveRepository, IEmployeeLeaveUow unitOfWork)
        {
            _leaveRepository = leaveRepository;
            _unitOfWork = unitOfWork;
        }
        public CreateAndUpdateLeaveDto CreateLeave(CreateAndUpdateLeaveDto leaveDto)
        {
            _leaveRepository.CreateLeave(leaveDto);
            _unitOfWork.SaveChanges();
            return leaveDto;
        }

        public void DeleteLeave(int leaveId)
        {
            _leaveRepository.DeleteLeave(leaveId);
            _unitOfWork.SaveChanges();
        }

        public LeaveDto GetLeaveById(int leaveId)
        {
            return _leaveRepository.GetLeaveById(leaveId);
        }

        public List<LeaveDto> GetFilteredLeaves(QueryObjectLeave query)
        {
            return _leaveRepository.GetFilteredLeaves(query);
        }

        public List<LeaveDto> GetLeaves()
        {
            return _leaveRepository.GetLeaves();
        }

        public bool LeaveExists(int leaveId)
        {
            return _leaveRepository.LeaveExists(leaveId);
        }
        public bool LeaveTypeExists(string leaveType)
        {
            return _leaveRepository.leaveTypeExists(leaveType);
        }

        public CreateAndUpdateLeaveDto UpdateLeave(int leaveId, CreateAndUpdateLeaveDto leave)
        {
            _leaveRepository.UpdateLeave(leaveId, leave);
            _unitOfWork.SaveChanges();
            return leave;
        }
    }
}
