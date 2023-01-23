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
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public List<DepartmentSupplier> DepartmentSuppliers { get; set; }
        public List<HoneyProductSupplier> HoneyProductSuppliers { get; set; }
        public Supplier() { }
        public Supplier(string supplierName, string address)
        {
            SupplierName = supplierName;
            Address = address;
            HoneyProductSuppliers = new List<HoneyProductSupplier>(){ };
            DepartmentSuppliers = new List<DepartmentSupplier>() { };
        }
    }
}
