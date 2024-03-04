using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.LeaveDtos
{
    public class CreateAndUpdateLeaveDto
    {
        public string? Type { get; set; }
        public int DefaultDays { get; set; }
        public bool IsDefault { get; set; }
    }
}
