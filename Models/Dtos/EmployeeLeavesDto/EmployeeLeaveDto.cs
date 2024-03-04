using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.EmployeeLeavesDto
{
    public class EmployeeLeaveDto
    {
        public int Id { get; set; }
        public Guid EmployeeGuid { get; set; }
        public int LeaveId { get; set; }
        public int YearId { get; set; }
        public int Balance { get; set; }
    }
}
