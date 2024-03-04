using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Helpers
{
    public class QueryObjectEmployee
    {
        public string? Name { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool IsDescending { get; set; } = false;
    }
}
