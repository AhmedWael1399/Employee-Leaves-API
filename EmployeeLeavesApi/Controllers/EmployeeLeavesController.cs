using EmployeeLeaveService.Interfaces;
using EmployeeLeaveService.Service;
using EmployeeLeavesRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dtos.EmployeeLeavesDto;

namespace EmployeeLeavesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLeavesController : ControllerBase
    {
        private readonly IEmployeeLeavesService _employeeLeaveService;
        public EmployeeLeavesController(IEmployeeLeavesService employeeLeaveService)
        {
            _employeeLeaveService = employeeLeaveService;
        }

        [HttpGet]
        public IActionResult GetEmployeesLeaves()
        {
            List<EmployeeLeaveDto> employeeLeaves = _employeeLeaveService.GetEmployeeLeaveYears();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(employeeLeaves);
        }

        
        [HttpGet("GetLeavesBalances")]
        public IActionResult GetEmployeesLeavesBalances(Guid employeeGuid)
        {
            List<LeaveTypeBalanceDto> leaveBalances = _employeeLeaveService.GetEmployeeLeaveBalances(employeeGuid);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(leaveBalances);
        }

        
        [HttpGet("GetEmployeeWithLeaves")]
        public IActionResult GetEmployeeWithLeaves(int page, int pageSize)
        {
            List<CreateEmployeeLeaveDto> createdEmployeeLeaves = _employeeLeaveService.GetAllEmployeesWithLeaves(page, pageSize);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(createdEmployeeLeaves);
        }
        

    }
}
