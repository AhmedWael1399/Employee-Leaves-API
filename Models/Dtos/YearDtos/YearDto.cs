﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.YearDtos
{
    public class YearDto
    {
        public int Id { get; set; }
        public int YearValue { get; set; }
    }
}
