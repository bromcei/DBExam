using ConsoleTables;
using DBExam.Classes;
using DBExam.DbContextServer;
using DBExam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBExam.Services
{
    public class ReportService
    {
        public DepartmentsRepository DepartmentsRepository { get; set; }
        public HoneyProductsRepository HoneyProductsRepository { get; set; }
        public SuppliersRepository SuppliersRepository { get; set; }
        public HoneyBadgerDbContext HoneyBadgerDB { get; set; }
        public ReportService()
        {
            DepartmentsRepository = new DepartmentsRepository();
            HoneyProductsRepository = new HoneyProductsRepository();
            SuppliersRepository = new SuppliersRepository();
            HoneyBadgerDB = new HoneyBadgerDbContext();
        }
        public ConsoleTable ShowAllDepartmentProducts(int departmentID)
        {
            using (HoneyBadgerDB)
            {
                List<HoneyProduct> departmentProducts = HoneyBadgerDB.HoneyProducts.Where(p => p.DepartmentID == departmentID).ToList();
                string departmentName = DepartmentsRepository.Retrieve(departmentID).DepartmentName;
                ConsoleTable resString = new ConsoleTable("HoneyId", "HoneyName", "PurchasePrice", "SellPrice", "DepartmentName");
                foreach (HoneyProduct product in departmentProducts)
                {
                    resString.AddRow(product.HoneyId, product.HoneyName, product.PurchasePrice, product.SellPrice, departmentName);
                }
                return resString;
            }
        }
        public ConsoleTable ShowAllDepartmentSuppliers(int departmentID)
        {
            using (HoneyBadgerDB)
            {
                List<Supplier> departmentSuppliers = HoneyBadgerDB.Suppliers.Where(s => s.DepartmentSuppliers.Any(d => d.DepartmentId == departmentID)).ToList();
                string departmentName = DepartmentsRepository.Retrieve(departmentID).DepartmentName;
                ConsoleTable resString = new ConsoleTable("SupplierId", "SupplierName", "SupplierAddress", "DepartmentName");
                foreach (Supplier supplier in departmentSuppliers)
                {
                    resString.AddRow(supplier.SupplierId, supplier.SupplierName, supplier.Address, departmentName);
                }
                return resString;
            }
        }
    }
}
