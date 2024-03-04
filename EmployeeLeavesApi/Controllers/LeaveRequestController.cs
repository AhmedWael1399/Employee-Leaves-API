using EmployeeLeaveService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dtos.LeaveRequestDtos;

namespace EmployeeLeavesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;
        public LeaveRequestController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        [HttpGet]
        public IActionResult GetLeaveRequests()
        {
            List<LeaveRequestDto> leaveRequests = _leaveRequestService.GetLeaveRequests();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(leaveRequests);
        }

        [HttpPost]
        public IActionResult CreateLeaveRequest([FromBody] LeaveRequestCreateDto leaveRequestDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _leaveRequestService.CreateLeaveRequest(leaveRequestDto);
            return Ok();
        }
    }
}
