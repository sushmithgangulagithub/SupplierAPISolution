using SupplierAPI.Interfaces;
using SupplierAPI.Models;
using SupplierAPI.Models.DTOs;
using SupplierAPI.Repositories;

namespace SupplierAPI.Services
{
    public class SupplierService : ISupplierService
    {

        private readonly IRepository<int, Supplier> _supplierRepository;

        public SupplierService(IRepository<int, Supplier> supplierRepo)
        {
            _supplierRepository = supplierRepo;
        }
        public Supplier AddANewSupplier(Supplier supplier)
        {
            //throw new NotImplementedException();
            return _supplierRepository.Add(supplier);
        }

        public List<Supplier> GetAllSuppliers()
        {
            //throw new NotImplementedException();
            return _supplierRepository.GetAll();
        }

        public Supplier UpdatePhone(SupplierPhoneDTO supplier)
        {
            var mysupplier = _supplierRepository.Get(supplier.Id);
            if (mysupplier != null)
            {
                mysupplier.Phone = supplier.Phone;
                return _supplierRepository.Update(mysupplier);
            }
            return null;
        }
    }
}
