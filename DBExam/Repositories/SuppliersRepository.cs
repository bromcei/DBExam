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
            List<Supplier> supplierList;
            using (HoneyBadgerDB)
            {
                supplierList = HoneyBadgerDB.Suppliers.ToList();
            }
            return supplierList;
        }
        public Supplier Retrieve(string suplierName)
        {
            Supplier supplier;
            using (HoneyBadgerDB)
            {
                supplier = HoneyBadgerDB.Suppliers.FirstOrDefault(s => s.SupplierName == suplierName);
            }
            return supplier;
        }
        public void AddNewSupplier(Supplier suplier)
        {
            using (HoneyBadgerDB)
            {
                HoneyBadgerDB.Suppliers.Add(suplier);
                HoneyBadgerDB.SaveChanges();
            }
        }
    }
}
