using Database.DoFactoryV2;
using Database.DoFactoryV3;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Multitenancy.SchemaVersioning.Controllers.V3
{
    [ApiVersion("1.2")]
    [ApiController]
    [Route("{__tenant__=}/api/v{version:apiVersion}/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly DoFactoryV3Context _context;
        public EmployeeController(DoFactoryV3Context context)
        {
            _context = context;
        }

        [HttpGet]        
        public IActionResult GetEmployees()
        {
            return Ok(_context.Employees.ToList());
        }
    }
}
