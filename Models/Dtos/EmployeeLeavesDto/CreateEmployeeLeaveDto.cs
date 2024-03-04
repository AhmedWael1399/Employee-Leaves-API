using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Dtos.LeaveDtos;

namespace Models.Dtos.EmployeeLeavesDto
{
    public class CreateEmployeeLeaveDto
    {
        public Guid EmployeeGuid { get; set; }
        public string? EmployeeName { get; set; }
        public List<LeaveEmployeeLeaveDto>? Leaves { get; set; }
        public int LeaveDays { get; set; }
        public int TotalDays { get; set; } 
    }
}
