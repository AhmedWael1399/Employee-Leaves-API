using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Dtos.LeaveRequestDtos
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
        public Guid EmployeeGuid { get; set; }
        public int LeaveId { get; set; }
        public int YearId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
        public int Days { get; set; }
        public bool Approved { get; set; }
    }
}
