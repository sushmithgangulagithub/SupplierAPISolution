using SupplierAPI.Models.DTOs;
using SupplierAPI.Models;

namespace SupplierAPI.Interfaces
{
    public interface ISupplierService
    {

        List<Supplier> GetAllSuppliers();

        Supplier AddANewSupplier(Supplier supplier);
        Supplier UpdatePhone(SupplierPhoneDTO supplier);


    }
}
