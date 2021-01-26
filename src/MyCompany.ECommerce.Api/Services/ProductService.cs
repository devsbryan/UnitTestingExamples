using MyCompany.ECommerce.Api.Models;

namespace MyCompany.ECommerce.Api.Services
{
    public class ProductService : IProductService
    {
        public Product GetProduct(int id)
        {
            return new Product {Id = id};
        }
    }
}
