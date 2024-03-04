using EmployeeLeaveService.Interfaces;
using EmployeeLeaveService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dtos.YearDtos;

namespace EmployeeLeavesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearController : ControllerBase
    {
        private readonly IYearService _yearService;
        public YearController(IYearService yearService)
        {
            _yearService = yearService;
        }

        [HttpGet]
        public IActionResult GetYears()
        {
            List<YearDto> years = _yearService.GetYears();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(years);
        }

        [HttpGet("{yearId}")]
        public IActionResult GetSingleYear(int yearId)
        {
            YearDto year = _yearService.GetYearById(yearId);
            if (year == null)
            {
                return NotFound($"Year {yearId} doesn't exist!!");
            }
            return Ok(year);
        }

        
        [HttpPost]
        public IActionResult CreateYear(int yearValue)
        {
            Year year = new() { YearValue = yearValue };
            _yearService.CreateYear(year);
            return Ok();
        }
        
        /*
        [HttpPut("{id}")]
        public IActionResult UpdateYear(Guid id, [FromBody] Year yearName)
        {
            bool y = _yearService.YearExists(id);
            if (!y)
            {
                return NotFound($"Year Id {yearName.YearGuid} doesn't exist!!");
            }
            _yearService.UpdateYear(yearName);
            return Ok();
        }
        

        [HttpDelete("{id}")]
        public IActionResult RemoveYear(Guid yearId)
        {
            bool y = _yearService.YearExists(yearId);
            if (!y)
            {
                return NotFound($"Year Id {yearId} doesn't exist!!");
            }
            _yearService.DeleteYear(yearId);
            return Ok();
        }
        */
    }
}
