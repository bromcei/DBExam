using DBExam.Classes;
using DBExam.DbContextServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBExam.Repositories
{
    public class ProductsRepository
    {
        public HoneyBadgerDbContext HoneyBadgerDB { get; set; }

        public ProductsRepository()
        {
            HoneyBadgerDB = new HoneyBadgerDbContext();
        }

        public List<Product> Retrieve()
        {
            return HoneyBadgerDB.Suppliers.ToList();
        }
        public Product Retrieve(string productName)
        {
            return HoneyBadgerDB.Products.Where(s => s.ProductName == productName).FirstOrDefault();
        }
        public void AddNewProduct(Product product)
        {
            HoneyBadgerDB.Products.Add(product);
            HoneyBadgerDB.SaveChanges();
        }
    }
}
