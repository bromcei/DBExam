using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBExam.Classes
{
    public class Supplier
    {
        [Key]
        public Guid Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public List<Product> Products { get; set; }
        public Supplier(string supplierName, string address)
        {
            Id = Guid.NewGuid();
            SupplierName = supplierName;
            Address = address;
            Products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
