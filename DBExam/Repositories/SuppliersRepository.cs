using DBExam.Classes;
using DBExam.DbContextServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBExam.Repositories
{
    public class SuppliersRepository
    {
        public HoneyBadgerDbContext HoneyBadgerDB { get; set; }

        public SuppliersRepository()
        {
            HoneyBadgerDB = new HoneyBadgerDbContext();
        }
        
        public List<Supplier> Retrieve()
        {
            return HoneyBadgerDB.Suppliers.ToList();
        }
        public Supplier Retrieve(string suplierName)
        {
            return HoneyBadgerDB.Suppliers.Where(s => s.SupplierName == suplierName).FirstOrDefault();
        }
        public void AddNewSupplier(Supplier suplier)
        {
            HoneyBadgerDB.Suppliers.Add(suplier);
            HoneyBadgerDB.SaveChanges();
        }
    }
}
