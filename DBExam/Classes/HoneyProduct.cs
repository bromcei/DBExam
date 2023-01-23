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
        public int HoneyId { get; set; }
        public string HoneyName { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellPrice { get; set; }
        public int DepartmentID { get; set; }
        public Department ProductDepartment { get; set; }
        public List<HoneyProductSupplier> HoneyProductSuppliers { get; set; }

        public HoneyProduct() { }
        public HoneyProduct(string honeyName, decimal purchasePrice)
        {
            HoneyName = honeyName;
            PurchasePrice = purchasePrice;
            SellPrice = purchasePrice * 2.5M;
            HoneyProductSuppliers = new List<HoneyProductSupplier>();
            //ProductDepartment = productDepartment;
        }

    }
}
