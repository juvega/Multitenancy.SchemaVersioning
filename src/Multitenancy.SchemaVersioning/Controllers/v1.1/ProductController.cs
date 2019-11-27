using Database.DoFactoryV2;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Multitenancy.SchemaVersioning.Controllers.V2
{
    [ApiVersion("1.1")]
    [ApiController]
    [Route("{__tenant__=}/api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DoFactoryV2Context _context;
        public ProductController(DoFactoryV2Context context)
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
