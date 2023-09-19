using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Viventium.Data;
using Viventium.Data.DbContext;
using Viventium.Data.DbContext.Models;
using Viventium.Data.Models;
using Viventium.Data.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Viventium.API.Controllers
{
    [ApiController]
    [Route("Data")]
    public class DataController : ViventiumControllerBase
    {
        private ICsvService _csvService;

        public DataController(CompanyDbContext dbContext, ICsvService csvService) : base(dbContext)
        {
            _csvService = csvService;
        }

        [HttpPost("DataStore")]
        public async Task<IActionResult> DataStore([FromForm]string csv)
        {
            try
            {

                await _dbContext.Companies.ExecuteDeleteAsync();
                await _dbContext.EmployeeHeaders.ExecuteDeleteAsync();


                //Populate with test data for now to eliminate newline problems for demo purposes
                var csvData = _csvService.ParseCsv(StaticTestData.CsvData);

                foreach (var group in csvData.GroupBy(c => c.CompanyId))
                {
                    var company = group.First();
                    _dbContext.Companies.Add(new Company()
                    {
                        Id = company.CompanyId,
                        Code = company.CompanyCode,
                        Description = company.CompanyDescription,
                        EmployeeCount = group.Count(),
                    });

                    foreach (var employee in group.ToList())
                    {
                        _dbContext.EmployeeHeaders.Add(new EmployeeHeader()
                        {
                            CompanyId = company.CompanyId,
                            FirstName = employee.EmployeeFirstName,
                            LastName = employee.EmployeeLastName
                        });
                    }
                }

                

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
