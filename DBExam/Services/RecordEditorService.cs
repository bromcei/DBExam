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
    public class RecordEditorService
    {
        public DepartmentsRepository DepartmentsRepository { get; set; }
        public HoneyProductsRepository HoneyProductsRepository { get; set; }
        public SuppliersRepository SuppliersRepository { get; set; }
        public HoneyBadgerDbContext HoneyBadgerDB { get; set; }
        public RecordEditorService()
        {
            DepartmentsRepository = new DepartmentsRepository();
            HoneyProductsRepository = new HoneyProductsRepository();
            SuppliersRepository = new SuppliersRepository();
            HoneyBadgerDB = new HoneyBadgerDbContext();
        }
        public void AddNewDepartment(Department department)
        {
            DepartmentsRepository.AddDepartment(department);
        }
        public Department GetDepartment(string departmentName)
        {
            return DepartmentsRepository.Retrieve(departmentName);
        }
        public List<Department> GetAllDepartments()
        {
            return DepartmentsRepository.Retrieve();
        }
        public void AddNewHoneyProduct(HoneyProduct honeyProduct, string departmentName)
        {
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
        public HoneyProduct GetHoneyProduct(string honeyProductName)
        {
            return HoneyProductsRepository.Retrieve(honeyProductName);
        }
        public List<HoneyProduct> GetAllHoneyProducts()
        {
            return HoneyProductsRepository.Retrieve();
        }
        public void AddNewSupplier(Supplier supplier)
        {
            SuppliersRepository.AddNewSupplier(supplier);
        }
        public Supplier GetSupplier(string supplierName)
        {
            return SuppliersRepository.Retrieve(supplierName);
        }
        public List<Supplier> GetAllSuppliers()
        {
            return SuppliersRepository.Retrieve();
        }
    }
}
