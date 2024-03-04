using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.LeaveDtos
{
    public class LeaveEmployeeLeaveDto
    {
        public string? LeaveType { get; set; }
        public int LeaveDays { get; set; }
        public int DefaultDays { get; set; }
    }
}
