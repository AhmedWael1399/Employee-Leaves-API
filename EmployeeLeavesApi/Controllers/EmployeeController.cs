using EmployeeLeaveService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Models.Dtos.EmployeeDtos;
using Models.Helpers;

namespace EmployeeLeavesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetEmployees([FromQuery] QueryObjectEmployee query)
        {
            List<EmployeeDto> employees = _employeeService.GetFilteredEmployees(query);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(employees);
        }

        [HttpGet("{employeeId:Guid}")]
        public IActionResult GetSingleEmployee(Guid employeeId)
        {
            EmployeeDto employee = _employeeService.GetEmployeeById(employeeId);
            if (employee == null)
            {
                return NotFound($"Employee {employeeId} doesn't exist!!");
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployeeAndLeave(string employeeName)
        {
            Employee employee = new() { Name = employeeName };
            _employeeService.CreateEmployeeLeaves(employee);
            return Ok();
        }
        [HttpPut("{employeeId:Guid}")]
        public IActionResult UpdateEmployee(Guid employeeId, [FromBody] CreateAndUpdateEmployeeDto employeeName)
        {
            bool e = _employeeService.EmployeeExists(employeeId);
            if (!e)
            {
                return NotFound($"Employee Id {employeeId} doesn't exist!!");
            }
            _employeeService.UpdateEmployee(employeeId, employeeName);
            return Ok();
        }

        [HttpDelete("{employeeId:Guid}")]
        public IActionResult RemoveEmployee(Guid employeeId)
        {
            bool e = _employeeService.EmployeeExists(employeeId);
            if (!e)
            {
                return NotFound($"Employee Id {employeeId} doesn't exist!!");
            }
            _employeeService.DeleteEmployee(employeeId);
            return Ok();
        }
    }
}
