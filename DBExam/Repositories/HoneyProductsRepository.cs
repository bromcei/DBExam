using DBExam.Classes;
using DBExam.DbContextServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBExam.Repositories
{
    public class HoneyProductsRepository
    {
        public HoneyBadgerDbContext HoneyBadgerDB { get; set; }

        public HoneyProductsRepository()
        {
            HoneyBadgerDB = new HoneyBadgerDbContext();
        }

        public List<HoneyProduct> Retrieve()
        {
            return HoneyBadgerDB.HoneyProducts.ToList();
        }
        public HoneyProduct Retrieve(string productName)
        {
            return HoneyBadgerDB.HoneyProducts.Where(s => s.HoneyName == productName).FirstOrDefault();
        }
        public void AddNewProduct(HoneyProduct product)
        {
            HoneyBadgerDB.HoneyProducts.Add(product);
            HoneyBadgerDB.SaveChanges();
        }
        public void AddNewProducts(List<HoneyProduct> products)
        {
            HoneyBadgerDB.HoneyProducts.AddRange(products);
            HoneyBadgerDB.SaveChanges();
        }
    }
}
