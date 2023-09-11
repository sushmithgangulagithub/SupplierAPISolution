using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using SupplierAPI.Interfaces;
using SupplierAPI.Models;
using SupplierAPI.Models.DTOs;
using SupplierAPI.Services;

namespace SupplierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        private readonly ISupplierService _supplierService;
        private readonly IRepository<int, Supplier> _repo;
        public SupplierController(ISupplierService supplierService, IRepository<int, Supplier> repo)
        {
            _supplierService = supplierService;
            _repo = repo;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _supplierService.GetAllSuppliers();
            if (result == null)
            {
                return NotFound("No suppliers are there at this moment");
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _supplierService.AddANewSupplier(supplier);
                    return Created("", result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);
        }

        [HttpPut("Phone")]

        public ActionResult UpdatePhone(SupplierPhoneDTO supphone)
        {
            try
            {

                var result = _supplierService.UpdatePhone(supphone);
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