using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viventium.Data.Models;

namespace Viventium.Data.Services
{
    public interface ICsvService
    {
        IEnumerable<CsvRow> ParseCsv(string csv);
    }
}
