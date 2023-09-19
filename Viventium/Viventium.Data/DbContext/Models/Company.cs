﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viventium.Data.DbContext.Models
{
    public class Company
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int EmployeeCount { get; set; }
        public IEnumerable<EmployeeHeader> EmployeeHeaders { get; set; }
    }
}
