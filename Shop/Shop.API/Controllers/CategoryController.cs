using Microsoft.AspNetCore.Mvc;

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
        public string Post()
        {
            return "POST";
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
