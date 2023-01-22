using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DBExam.DbContextServer;
using DBExam.Classes;

namespace DBExam.Repositories
{
    public class DepartmentsRepository
    {
        public HoneyBadgerDbContext HoneyBadgerDB { get; set; }
        public DepartmentsRepository()
        {
            HoneyBadgerDB = new HoneyBadgerDbContext();
        }
        public List<Department> Retrieve()
        {
            return HoneyBadgerDB.Departments.ToList(); 
        }
        public Department Retrieve(string departmentName)
        {
            return HoneyBadgerDB.Departments.Where(d => d.DepartmentName == departmentName).FirstOrDefault();
        }
        public void AddDepartment(Department department)
        {
            HoneyBadgerDB.Departments.Add(department);
            HoneyBadgerDB.SaveChanges();
        }
        public void AddProductsToDepartment(string departmentName, List<HoneyProduct> products)
        {
            Department department = Retrieve(departmentName);
            department.HoneyProducts = products;
            HoneyBadgerDB.SaveChanges();
        }

    }
}
