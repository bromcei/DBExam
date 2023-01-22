using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBExam.Classes
{
    public class HoneyProduct
    {
        [Key]
        public Guid HoneyId { get; set; }
        public string HoneyName { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellPrice { get; set; }
//        public Department ProductDepartment { get; set; }
        public List<Supplier> SupplierList { get; set; }

        public HoneyProduct() { }
        public HoneyProduct(string honeyName, decimal purchasePrice)
        {
            HoneyId = Guid.NewGuid();
            HoneyName = honeyName;
            PurchasePrice = purchasePrice;
            SellPrice = purchasePrice * 2.5M;
            SupplierList = new List<Supplier>();
            //ProductDepartment = productDepartment;
        }

        public void AddSuplier(Supplier suplier)
        {
            SupplierList.Add(suplier);
        }
        public void AddSupliers(List<Supplier> supliers)
        {
            SupplierList.AddRange(supliers);
        }
    }
}
