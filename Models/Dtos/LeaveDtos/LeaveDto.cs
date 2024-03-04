using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Dtos.LeaveDtos
{
    public class LeaveDto
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public int DefaultDays { get; set; }
        public bool IsDefault { get; set; }
    }
}
