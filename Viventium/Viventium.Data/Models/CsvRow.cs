using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace Viventium.Data.Models
{
    public class CsvRow
    {
        public long CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyDescription { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
    }
}
