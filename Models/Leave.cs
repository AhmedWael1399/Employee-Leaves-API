using System.Text.Json.Serialization;

namespace Models
{
    public class Leave
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public int DefaultDays { get; set; }
        public bool IsDefault { get; set; }
        public ICollection<EmployeeLeave>? EmployeeLeaves { get; set; } = new List<EmployeeLeave>();
        public ICollection<LeaveRequest>? LeaveRequests { get; set; } = new List<LeaveRequest>();
    }
}
