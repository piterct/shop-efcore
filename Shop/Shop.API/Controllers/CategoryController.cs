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
        [Route("{id:int}")]
        public Category Put(int id, [FromBody] Category model)
        {
            if (model.Id == id)
            {
                return model;

            }

            return null;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public string Delete()
        {
            return "DELETE";
        }
    }
}
