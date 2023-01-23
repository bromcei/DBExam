using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBExam.Classes
{
    public class DepartmentSupplier
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
