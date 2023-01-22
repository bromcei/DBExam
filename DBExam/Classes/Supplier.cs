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
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public List<HoneyProduct> HoneyProducts { get; set; }
        public Supplier(string supplierName, string address)
        {
            SupplierId = Guid.NewGuid();
            SupplierName = supplierName;
            Address = address;
            HoneyProducts = new List<HoneyProduct>();
        }
        public void AddProduct(HoneyProduct product)
        {
            HoneyProducts.Add(product);
        }
        public void AddProducts(List<HoneyProduct> products)
        {
            HoneyProducts.AddRange(products);
        }
    }
}
