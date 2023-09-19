using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Viventium.Data.Models;

namespace Viventium.Data.Services
{
    public class CsvService : ICsvService
    {
        private CsvConfiguration config;

        public CsvService()
        {
            config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
                PrepareHeaderForMatch = args => args.Header.ToLower(),
                HasHeaderRecord = true,
            };
        }
        public IEnumerable<CsvRow> ParseCsv(string csv)
        {
            if (csv == null) throw new Exception("Cannot parse an empty csv.");
            var rows = new List<CsvRow>();
            var lines = csv.Split(Environment.NewLine).ToList();
            lines.RemoveAt(0);
            foreach (var line in lines)
            {
                if (line == null || line.Length == 0) continue;
                var cells = line.Split(',');
                rows.Add(new CsvRow()
                {
                    CompanyId = Convert.ToInt64(cells[0]),
                    CompanyCode = cells[1],
                    CompanyDescription = cells[2],
                    EmployeeFirstName = cells[4],
                    EmployeeLastName = cells[5]
                });
            }

            return rows;

        }
    }
}
