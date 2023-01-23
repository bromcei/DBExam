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
            List<HoneyProduct> products;
            using (HoneyBadgerDB)
            {
                products = HoneyBadgerDB.HoneyProducts.ToList();
            }
            return products;
        }
        public HoneyProduct Retrieve(string productName)
        {
            HoneyProduct product;
            using (HoneyBadgerDB)
            {
                product = HoneyBadgerDB.HoneyProducts.FirstOrDefault(s => s.HoneyName == productName);
            }
            return product;
        }
        public void AddNewProduct(HoneyProduct product)
        {
            
            using (HoneyBadgerDB)
            {
                HoneyBadgerDB.HoneyProducts.Add(product);
                HoneyBadgerDB.SaveChanges();
            }
            
        }
        public void AddNewProducts(List<HoneyProduct> products)
        {
            using (HoneyBadgerDB)
            {
                HoneyBadgerDB.HoneyProducts.AddRange(products);
                HoneyBadgerDB.SaveChanges();
            }
            
        }
    }
}
