using DBExam.Classes;
using DBExam.DbContextServer;
using DBExam.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBExam.Services
{
    public class RecordEditorService
    {
        public DepartmentsRepository DepartmentsRepository { get; set; }
        public HoneyProductsRepository HoneyProductsRepository { get; set; }
        public SuppliersRepository SuppliersRepository { get; set; }
        public RecordEditorService()
        {
            DepartmentsRepository = new DepartmentsRepository();
            HoneyProductsRepository = new HoneyProductsRepository();
            SuppliersRepository = new SuppliersRepository();
        }
        public void AddNewDepartment(Department department)
        {
            DepartmentsRepository.AddDepartment(department);
        }
        public List<Department> GetAllDepartments()
        {
            return DepartmentsRepository.Retrieve();
        }
        public void AddNewHoneyProduct(HoneyProduct honeyProduct, string departmentName)
        {
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                Department department = HoneyBadgerDB.Departments.FirstOrDefault(d => d.DepartmentName == departmentName);
                if (department != null)
                {
                    department.HoneyProducts.Add(honeyProduct);
                    HoneyBadgerDB.SaveChanges();
                }
            }
        }
        public void AddNewHoneyProduct(HoneyProduct honeyProduct, int departmentID)
        {
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                Department department = HoneyBadgerDB.Departments.FirstOrDefault(d => d.DepartmentId == departmentID);
                if (department != null)
                {
                    department.HoneyProducts.Add(honeyProduct);
                    HoneyBadgerDB.SaveChanges();
                }
            }
        }
        public void AddNewHoneySupplier(Supplier supplier)
        {
            SuppliersRepository.AddNewSupplier(supplier);
        }
        public void AssignSupplierToDepartment(string supplierName, string departmentName)
        {
            DepartmentSupplier departSupplier = new DepartmentSupplier();
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                Supplier supplier = HoneyBadgerDB.Suppliers.FirstOrDefault(s => s.SupplierName == departmentName);
                Department department = HoneyBadgerDB.Departments.FirstOrDefault(d => d.DepartmentName == departmentName);
                if (department != null && supplier != null)
                {
                    departSupplier.Supplier = supplier;
                    departSupplier.Department = department;  
                    HoneyBadgerDB.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Department or Supplier not found in DB");
                }
            }
        }
        public void AssignSupplierToDepartment(int supplierID, int departmentID)
        {
            DepartmentSupplier departSupplier = new DepartmentSupplier();
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                Supplier supplier = HoneyBadgerDB.Suppliers.FirstOrDefault(s => s.SupplierId == supplierID);
                Department department = HoneyBadgerDB.Departments.FirstOrDefault(d => d.DepartmentId == departmentID);
                if (department != null && supplier != null)
                {
                    departSupplier.Supplier = supplier;
                    departSupplier.Department = department;
                    HoneyBadgerDB.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Department or Supplier not found in DB");
                }
            }
        }
        public void AssignDepartmentSuppliersToProduct(int productID)
        {
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                HoneyProduct product = HoneyBadgerDB.HoneyProducts.FirstOrDefault(p => p.HoneyId == productID);
                if (product != null)
                {
                    Department prodDepartment = HoneyBadgerDB.Departments.FirstOrDefault(d => d.DepartmentId == product.DepartmentID);
                    List<DepartmentSupplier> departmentSuppliers = prodDepartment.DepartmentSuppliers;
                    List<HoneyProductSupplier> productSuppliers = new List<HoneyProductSupplier>() { };
                    //Delete previous suppliers 
                    //HoneyBadgerDB.HoneyProductsSupliers.RemoveRange(HoneyBadgerDB.HoneyProductsSupliers.Where(ps => ps.HoneyProductId == productID)); If it is big set it could run out of memory
                    HoneyBadgerDB.HoneyProductsSupliers.FromSqlRaw($"DELETE FROM dbo.HoneyProductsSupliers WHERE HoneyProductId = {productID}");


                    foreach (DepartmentSupplier departmentSupplier in departmentSuppliers)
                    {
                        HoneyProductSupplier honeyProductSupplier = new HoneyProductSupplier();
                        honeyProductSupplier.Supplier = departmentSupplier.Supplier;
                        honeyProductSupplier.HoneyProduct = product;
                        productSuppliers.Add(honeyProductSupplier);
                    }
                    product.HoneyProductSuppliers = productSuppliers;
                    HoneyBadgerDB.SaveChanges();
                }

                else
                {
                    Console.WriteLine("Honey product not found");
                }
            }
        }
        public void ChangeProductDepartmentAndSuppliers(int productID, int newDepartmentID)
        {
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                HoneyProduct product = HoneyBadgerDB.HoneyProducts.FirstOrDefault(p => p.HoneyId == productID);
                Department newDepartment = HoneyBadgerDB.Departments.FirstOrDefault(d => d.DepartmentId == newDepartmentID);
                if (product != null && newDepartment != null)
                {
                    product.ProductDepartment = newDepartment;
                    HoneyBadgerDB.SaveChanges();
                    AssignDepartmentSuppliersToProduct(productID);
                }
                else
                {
                    Console.WriteLine("Honey product or Department not found");
                }
            }
        }
    }
}
