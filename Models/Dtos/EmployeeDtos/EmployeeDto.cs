﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.EmployeeDtos
{
    public class EmployeeDto
    {
        public Guid EmployeeGuid { get; set; }
        public string? Name { get; set; }
    }
}
