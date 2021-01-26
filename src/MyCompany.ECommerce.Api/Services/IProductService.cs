using MyCompany.ECommerce.Api.Models;

namespace MyCompany.ECommerce.Api.Services
{
    public interface IProductService
    {
        Product GetProduct(int id);
    }
}