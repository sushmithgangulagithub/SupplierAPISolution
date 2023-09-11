using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SupplierAPI.Models
{
    public class Supplier
    {

        public int Id { get; set; }
        public String Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }


        public List<Product>? Products { get; set; }

    }
}
