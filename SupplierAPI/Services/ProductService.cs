using SupplierAPI.Interfaces;
using SupplierAPI.Models;
using SupplierAPI.Models.DTOs;
using SupplierAPI.Repositories;

namespace SupplierAPI.Services
{
    public class ProductService : IProductService

    {
        private readonly IRepository<int, Product> _productRepository;

        public ProductService(IRepository<int, Product> productRepo)
        {
            _productRepository = productRepo;
        }


        public Product AddANewProduct(Product product)
        {
            // throw new NotImplementedException();
            return _productRepository.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            // throw new NotImplementedException();
            return _productRepository.GetAll();
        }

        public Product ToggleProductStatus(int id)
        {
            // throw new NotImplementedException();
            var product = _productRepository.Get(id);
            if (product != null)
            {
                if (product.IsNull == null)
                {
                    product.IsNull = false;
                }
                product.IsNull = !product.IsNull;
                return _productRepository.Update(product);
            }
            return null;
        }

        public Product UpdatePrice(ProductPriceDTO product)
        {
            // throw new NotImplementedException();

            var myproduct = _productRepository.Get(product.Id);
            if (myproduct != null)
            {
                myproduct.Price = product.Price;
                return _productRepository.Update(myproduct);
            }
            return null;
        }


    }
}