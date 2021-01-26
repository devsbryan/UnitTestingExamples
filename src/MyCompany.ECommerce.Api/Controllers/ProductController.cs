using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.Api.Services;

namespace MyCompany.ECommerce.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IEventNotificationService _eventNotificationService;

        public ProductController(
            IProductService productService,
            IEventNotificationService eventNotificationService)
        {
            _productService = productService;
            _eventNotificationService = eventNotificationService;
        }

        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProduct(id);

            _eventNotificationService.RaiseEvent("ProductRetrieval", id);

            return new OkObjectResult(product);
        }
    }
}
