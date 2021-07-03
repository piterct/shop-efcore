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

        [HttpPost]
        [Route("")]
        public string Post()
        {
            return "Hello World!";
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
