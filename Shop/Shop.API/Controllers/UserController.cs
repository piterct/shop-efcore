using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Data;
using Shop.API.Models;
using System;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post([FromServices] DataContext context, [FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                context.Users.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }

            catch (Exception)
            {
                return BadRequest(new { message = "Could not create user" });
            }
        }
    }
}
