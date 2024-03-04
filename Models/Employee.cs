using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class Employee
    {
        [Key]
        [Column("Id")]
        public Guid EmployeeGuid { get; set; }
        public string? Name { get; set; }
        public ICollection<EmployeeLeave>? EmployeeLeaves { get; set; } = new List<EmployeeLeave>();
        public ICollection<LeaveRequest>? LeaveRequests { get; set; } = new List<LeaveRequest>();
    }
}
