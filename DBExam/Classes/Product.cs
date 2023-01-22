using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBExam.Classes
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellPrice { get; set; }
        public Department ProductDepartment { get; set; }
        public List<Supplier> SupplierList { get; set; }

        public Product() { }
        public Product(string productName, decimal purchasePrice, Department productDepartment)
        {
            Id = Guid.NewGuid();
            ProductName = productName;
            PurchasePrice = purchasePrice;
            SellPrice = purchasePrice * 2.5M;
            SupplierList = new List<Supplier>();
            ProductDepartment = productDepartment;
        }

        public void AddSuplier(Supplier suplier)
        {
            SupplierList.Add(suplier);
        }
    }
}
