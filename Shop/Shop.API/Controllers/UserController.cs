using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.API.Data;
using Shop.API.Models;
using Shop.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
        {
            var users = await context
                .Users
                .AsNoTracking()
                .ToListAsync();

            return users;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<User>> Post([FromServices] DataContext context, [FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                model.Role = "employee";

                context.Users.Add(model);
                await context.SaveChangesAsync();

                model.Password = "";
                return Ok(model);
            }

            catch (Exception)
            {
                return BadRequest(new { message = "Could not create user" });
            }
        }


        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<dynamic>> Put([FromServices] DataContext context, int id, [FromBody] User model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.Id)
                return NotFound(new { message = "User not found! " });

            try
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Could not update user" });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromServices] DataContext context, [FromBody] User model)
        {
            var user = await context.Users
                .AsNoTracking()
                .Where(x => x.Username == model.Username && x.Password == model.Password)
                .FirstOrDefaultAsync();

            if (user == null)
                return NotFound(new { messsage = "User not found" });

            var token = TokenService.GenerateToken(user);

            return new
            {
                token = token
            };
        }
    }
}
