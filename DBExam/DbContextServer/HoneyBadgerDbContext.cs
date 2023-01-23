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
        public DbSet<HoneyProduct> HoneyProducts { get; set; }
        public DbSet<HoneyProductSupplier> HoneyProductsSupliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer($@"Data Source=localhost;Initial Catalog=HoneyBadger;Integrated Security=True");
            options.UseSqlServer($@"Data Source=TOMASC-PC\SQLEXPRESS;Initial Catalog=HoneyBadger;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoneyProduct>().HasOne<Department>(p => p.ProductDepartment).WithMany(d => d.HoneyProducts).HasForeignKey(p => p.DepartmentID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Supplier>().HasOne<Department>(s => s.SupplierDepartment).WithMany(d => d.Suppliers).HasForeignKey(s => s.DepartmentID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<HoneyProductSupplier>().HasKey(ps => new { ps.HoneyId, ps.SupplierId });
        }
    }
}
