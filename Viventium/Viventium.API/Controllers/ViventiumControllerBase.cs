using Microsoft.AspNetCore.Mvc;
using Viventium.Data.DbContext;

namespace Viventium.API.Controllers
{
    [ApiController]
    public class ViventiumControllerBase : Controller
    {
        protected CompanyDbContext _dbContext;

        public ViventiumControllerBase(CompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
