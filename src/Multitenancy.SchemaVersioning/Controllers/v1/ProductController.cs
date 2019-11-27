using Database.DoFactory;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Multitenancy.SchemaVersioning.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("{__tenant__=}/api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DoFactoryContext _context;
        public ProductController(DoFactoryContext context)
        {
            _context = context;
        }

        [HttpGet]        
        public IActionResult GetProduct()
        {
            return Ok(_context.Product.ToList());
        }
    }
}
