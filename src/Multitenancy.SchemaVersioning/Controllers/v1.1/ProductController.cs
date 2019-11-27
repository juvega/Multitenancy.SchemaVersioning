using Database.DoFactoryV2;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Multitenancy.SchemaVersioning.Controllers.V2
{
    [Route("{__tenant__=}/api/v1.1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DoFactoryNewContext _context;
        public ProductController(DoFactoryNewContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ApiVersion("1.1")]
        public IActionResult GetProduct()
        {
            return Ok(_context.Product.ToList());
        }
    }
}
