﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viventium.Data.DbContext.Models
{
    public class EmployeeHeader
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName() => $"{FirstName} {LastName}";
    }
}
