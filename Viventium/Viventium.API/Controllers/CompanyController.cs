using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viventium.Data.DbContext;
using Viventium.Data.DbContext.Models;

namespace Viventium.API.Controllers
{
    [ApiController]
    [Route("Company")]
    public class CompanyController : ViventiumControllerBase
    {

        public CompanyController(CompanyDbContext dbContext) : base(dbContext) //Normally like to inject the interface rather than concrete class
        {

        }

        [HttpGet]
        public async Task<List<CompanyHeader>> Index()
        {
            var companyHeaders = await _dbContext.Companies.Select(c => new CompanyHeader()
            {
                Code = c.Code,
                Description = c.Description,
                EmployeeCount = c.EmployeeCount,
                Id = c.Id
            }).ToListAsync();
            return companyHeaders;
        }

        [HttpGet("/{companyId}")]
        public async Task<ActionResult<Company>> GetCompany(long companyId)
        {
            var company = await _dbContext.Companies.Include(c => c.EmployeeHeaders).FirstOrDefaultAsync(c => c.Id == companyId);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }
    }
}
