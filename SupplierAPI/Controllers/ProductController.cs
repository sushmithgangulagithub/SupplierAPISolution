using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierAPI.Interfaces;
using SupplierAPI.Models;
using SupplierAPI.Models.DTOs;
using SupplierAPI.Services;

namespace SupplierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IRepository<int, Product> _repo;
        public ProductController(IProductService productService, IRepository<int, Product> repo)
        {
            _productService = productService;
            _repo = repo;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _productService.GetAllProducts();
            if (result == null)
            {
                return NotFound("No products are there at this moment");
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(Product supplier)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _productService.AddANewProduct(supplier);
                    return Created("", result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);
        }





        [HttpPut("UpdateProductStatus")]

        public ActionResult PutChangesStatus(int id)
        {
            try
            {

                var result = _productService.ToggleProductStatus(id);
                if (result == null)

                    return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Price")]

        public ActionResult UpdatePrice(ProductPriceDTO price)
        {
            try
            {

                var result = _productService.UpdatePrice(price);
                if (result == null)

                    return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _repo.Delete(id);
                return Ok(result);
            }
            catch (Exception e)
            {



                return BadRequest(e.Message);


            }
        }
    }
}
