using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBExam.Classes
{
    public class HoneyProductSupplier
    {
        public int HoneyProductId { get; set; }
        public HoneyProduct HoneyProduct { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
