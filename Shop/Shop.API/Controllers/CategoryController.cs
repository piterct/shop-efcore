using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.API.Data;
using Shop.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Categories.AsNoTracking().ToListAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id,
            [FromServices] DataContext context)
        {
            var categories = await context.Categories.AsNoTracking().FirstOrDefaultAsync();
            return Ok(categories);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Post([FromBody] Category model,
            [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }

            catch (Exception)
            {
                return BadRequest(new { message = "Could not create category" });
            }

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Category>>> Put(
            int id,
            [FromBody] Category model,
             [FromServices] DataContext context)
        {
            if (id != model.Id)
                return NotFound(new { message = "Category not found!" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Category>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }

            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "This value already updated ! " });
            }

            catch (Exception)
            {
                return BadRequest(new { message = "Could not update category" });
            }

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Category>>> Delete(
            int id,
             [FromServices] DataContext context)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound(new { message = "Category not found" });

            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return Ok(category);
            }

            catch (Exception)
            {
                return BadRequest(new { message = "Could not remove category" });
            }
        }
    }
}
