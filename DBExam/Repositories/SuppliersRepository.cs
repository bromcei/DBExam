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
        public List<Supplier> Retrieve()
        {
            List<Supplier> supplierList;
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                supplierList = HoneyBadgerDB.Suppliers.ToList();
            }
            return supplierList;
        }
        public Supplier Retrieve(string suplierName)
        {
            Supplier supplier;
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                supplier = HoneyBadgerDB.Suppliers.FirstOrDefault(s => s.SupplierName == suplierName);
            }
            return supplier;
        }
        public void AddNewSupplier(Supplier suplier)
        {
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                HoneyBadgerDB.Suppliers.Add(suplier);
                HoneyBadgerDB.SaveChanges();
            }
        }
    }
}
