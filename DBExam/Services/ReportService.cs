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
            using (new HoneyBadgerDbContext())
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
            using (new HoneyBadgerDbContext())
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
        public ConsoleTable ShowAllProductSuppliers(int productID)
        {
            using (new HoneyBadgerDbContext())
            {
                ConsoleTable resString = new ConsoleTable("SupplierId", "SupplierName", "SupplierAddress", "ProductName");
                List<Supplier> productSuppliers = HoneyBadgerDB.Suppliers.Where(s => s.HoneyProductSuppliers.Any(p => p.HoneyProductId == productID)).ToList();
                if(productSuppliers.Count == 0)
                {
                    return resString;
                }
                else
                {
                    string? productName = HoneyProductsRepository.Retrieve(productID).HoneyName;
                    
                    foreach (Supplier supplier in productSuppliers)
                    {
                        resString.AddRow(supplier.SupplierId, supplier.SupplierName, supplier.Address, productName);
                    }
                    return resString;
                }

            }
        }
        public ConsoleTable ShowAllDepartments()
        {
            using (new HoneyBadgerDbContext())
            {
                List<Department> departments = HoneyBadgerDB.Departments.ToList();
             
                ConsoleTable resString = new ConsoleTable("DepartmentID", "DepartmentName", "DepartmentAddress");
                foreach (Department department in departments)
                {
                    resString.AddRow(department.DepartmentId, department.DepartmentName, department.DepartmentAddress);
                }
                return resString;
            }
        }
        public ConsoleTable ShowAllSuppliers()
        {
            using (new HoneyBadgerDbContext())
            {
                List<Supplier> suppliers = HoneyBadgerDB.Suppliers.ToList();

                ConsoleTable resString = new ConsoleTable("SupplierID", "SupplierName", "SupplierAddress");
                foreach (Supplier supplier in suppliers)
                {
                    resString.AddRow(supplier.SupplierId, supplier.SupplierName, supplier.Address);
                }
                return resString;
            }
        }
        public ConsoleTable ShowAllProducts()
        {
            using (new HoneyBadgerDbContext())
            {
                List<HoneyProduct> products = HoneyBadgerDB.HoneyProducts.ToList();

                ConsoleTable resString = new ConsoleTable("HoneyId", "HoneyName", "PurchasePrice", "SellPrice");
                foreach (HoneyProduct product in products)
                {
                    resString.AddRow(product.HoneyId, product.HoneyName, product.PurchasePrice, product.SellPrice);
                }
                return resString;
            }
        }
    }
}
