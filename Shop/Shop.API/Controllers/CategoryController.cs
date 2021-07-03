using Microsoft.AspNetCore.Mvc;
using Shop.API.Models;

namespace Shop.API.Controllers
{
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Hello World!";
        }

        [HttpGet]
        [Route("{id:int}")]
        public string GetById(int id)
        {
            return "GET " + id.ToString();
        }

        [HttpPost]
        [Route("")]
        public Category Post([FromBody] Category model)
        {
            return model;
        }

        [HttpPut]
        [Route("")]
        public string Put()
        {
            return "Hello World!";
        }

        [HttpDelete]
        [Route("")]
        public string Delete()
        {
            return "Hello World!";
        }
    }
}
