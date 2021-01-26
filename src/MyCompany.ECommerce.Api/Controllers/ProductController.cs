using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.Api.Services;

namespace MyCompany.ECommerce.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IActionResult GetProduct(int id)
        {
            var productService = new ProductService();

            var product = productService.GetProduct(id);

            return new OkObjectResult(product);
        }
    }
}
