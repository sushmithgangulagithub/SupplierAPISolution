using SupplierAPI.Models;
using SupplierAPI.Models.DTOs;

namespace SupplierAPI.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product AddANewProduct(Product product);
        Product UpdatePrice(ProductPriceDTO product);

        Product ToggleProductStatus(int id);
    }
}
