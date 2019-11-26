using Database.DoFactory;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Multitenancy.SchemaVersioning.Controllers.V1
{
    [Route("api/v1.0/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DoFactoryContext _context;
        public ProductController(DoFactoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public IActionResult GetProduct()
        {
            return Ok(_context.Product.ToList());
        }
    }
}
