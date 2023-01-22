using DBExam.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DBExam.DbContextServer
{
    public class HoneyBadgerDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer($@"Data Source=localhost;Initial Catalog=HoneyBadger;Integrated Security=True");
        }
    }
}
