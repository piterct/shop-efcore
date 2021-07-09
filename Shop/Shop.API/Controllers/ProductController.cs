using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.API.Data;
using Shop.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context.Products.Include(x => x.Category).AsNoTracking().ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id,
          [FromServices] DataContext context)
        {
            var product = await context.Products.Include(x=> x.Category).AsNoTracking().FirstOrDefaultAsync();
            return Ok(product);
        }
    }
}
