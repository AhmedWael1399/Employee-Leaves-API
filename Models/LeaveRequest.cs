using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }

        [Column("EmployeeId")]
        public Guid EmployeeGuid { get; set; }
        public int LeaveId { get; set; }
        public int YearId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public  DateTime ToDate { get; set;}
        public int Days { get; set; }
        public bool Approved { get; set; }
        public Employee? Employee { get; set; }
        public Leave? Leave { get; set; }
        public Year? Year { get; set; }
    }
}
