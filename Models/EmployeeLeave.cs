using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class EmployeeLeave
    {
        public int Id { get; set; }

        [Column("EmployeeId")]
        public Guid EmployeeGuid { get; set; }
        public int LeaveId { get; set; }
        public int YearId { get; set; }
        public int Balance { get; set; }
        public Employee? Employee { get; set; }
        public Leave? Leave { get; set; }
        public Year? Year { get; set; }
    }
}
