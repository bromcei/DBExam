using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBExam.Classes
{
    public class Department
    {
        [Key]
        public Guid DepartemntId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAddress { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<HoneyProduct> HoneyProducts { get; set; }
        public Department(string departmentName, string departmentAddress)
        {
            DepartemntId = Guid.NewGuid();
            DepartmentName = departmentName;
            DepartmentAddress = departmentAddress;
            Suppliers = new List<Supplier>();
            HoneyProducts = new List<HoneyProduct>();
        }
        public void AddSuplier(Supplier suplier)
        {
            Suppliers.Add(suplier);
        }
        public void AddSupliers(List<Supplier> supliers)
        {
            Suppliers.AddRange(supliers);
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
