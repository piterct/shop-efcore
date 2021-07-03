using Microsoft.AspNetCore.Mvc;

namespace Shop.API.Controllers
{
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [Route("")]
        public string MyMethod()
        {
            return "Hello World!";
        }
    }
}
