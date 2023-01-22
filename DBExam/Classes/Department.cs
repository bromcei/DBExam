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
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAddress { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Product> Products { get; set; }
        public Department(string departmentName, string departmentAddress)
        {
            Id = Guid.NewGuid();
            DepartmentName = departmentName;
            DepartmentAddress = departmentAddress;
            Suppliers = new List<Supplier>();
            Products = new List<Product>();
        }
        public void AddSuplier(Supplier suplier)
        {
            Suppliers.Add(suplier);
        }
        public void AddSupliers(List<Supplier> supliers)
        {
            Suppliers.AddRange(supliers);
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void AddProducts(List<Product> products)
        {
            Products.AddRange(products);
        }
    }
}
