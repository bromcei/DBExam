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

        public List<HoneyProduct> Retrieve()
        {
            List<HoneyProduct> products;
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                products = HoneyBadgerDB.HoneyProducts.ToList();
            }
            return products;
        }
        public HoneyProduct Retrieve(string productName)
        {
            HoneyProduct product;
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                product = HoneyBadgerDB.HoneyProducts.FirstOrDefault(s => s.HoneyName == productName);
            }
            return product;
        }
        public HoneyProduct Retrieve(int productID)
        {
            HoneyProduct product;
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                product = HoneyBadgerDB.HoneyProducts.FirstOrDefault(s => s.HoneyId == productID);
            }
            return product;
        }
        public void AddNewProduct(HoneyProduct product)
        {

            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                HoneyBadgerDB.HoneyProducts.Add(product);
                HoneyBadgerDB.SaveChanges();
            }
            
        }
        public void AddNewProducts(List<HoneyProduct> products)
        {
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                HoneyBadgerDB.HoneyProducts.AddRange(products);
                HoneyBadgerDB.SaveChanges();
            }
            
        }
    }
}
