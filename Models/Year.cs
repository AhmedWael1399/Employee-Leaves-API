using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Year
    {
        public  int Id { get; set; }
        public  int YearValue { get; set; }
        public ICollection<EmployeeLeave>? EmployeesLeaves { get; set; } = new List<EmployeeLeave>();
        public ICollection<LeaveRequest>? LeaveRequests { get; set; } = new List<LeaveRequest>();
    }
}
