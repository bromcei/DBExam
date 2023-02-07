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
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAddress { get; set; }
        public List<DepartmentSupplier> DepartmentSuppliers { get; set; }
        public List<HoneyProduct> HoneyProducts { get; set; }
        public Department(string departmentName, string departmentAddress)
        {
            // uzsetint private viska 
            DepartmentName = departmentName;
            DepartmentAddress = departmentAddress;
            DepartmentSuppliers = new List<DepartmentSupplier>();
            HoneyProducts = new List<HoneyProduct>();
        }
    }
}
