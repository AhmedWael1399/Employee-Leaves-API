using EmployeeLeaveService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dtos.LeaveDtos;
using Models.Helpers;

namespace EmployeeLeavesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;
        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpGet]
        public IActionResult GetFilteredLeaves([FromQuery] QueryObjectLeave query)
        {
            List<LeaveDto> leaves = _leaveService.GetFilteredLeaves(query);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(leaves);
        }

        [HttpGet("{leaveId:int}")]
        public IActionResult GetSingleLeave([FromRoute] int leaveId)
        {
            LeaveDto leave = _leaveService.GetLeaveById(leaveId);
            if (leave == null)
            {
                return NotFound($"Leave {leaveId} doesn't exist!!");
            }
            return Ok(leave);
        }

        [HttpPost]
        public IActionResult CreateLeave([FromBody] CreateAndUpdateLeaveDto leaveDto)
        {
            if (_leaveService.LeaveTypeExists(leaveDto.Type)) 
            {
                return Conflict("Leave already exists.");
            }
            _leaveService.CreateLeave(leaveDto);
            return Ok();
        }

        [HttpPut("{leaveId:int}")]
        public IActionResult UpdateLeave([FromRoute] int leaveId, [FromBody] CreateAndUpdateLeaveDto leaveType)
        {
            bool l = _leaveService.LeaveExists(leaveId);
            if (!l)
            {
                return NotFound($"Leave Id {leaveId} doesn't exist!!");
            }
            _leaveService.UpdateLeave(leaveId, leaveType);
            return Ok();
        }

        [HttpDelete("{leaveId:int}")]
        public IActionResult RemoveLeave([FromRoute] int leaveId)
        {
            bool l = _leaveService.LeaveExists(leaveId);
            if (!l)
            {
                return NotFound($"Leave Id {leaveId} doesn't exist!!");
            }
            _leaveService.DeleteLeave(leaveId);
            return Ok();
        }
    }
}
