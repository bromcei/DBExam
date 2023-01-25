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
            List<Department> departments;
            using (HoneyBadgerDB)
            {
                departments = HoneyBadgerDB.Departments.ToList();
            }
            return departments; 
        }
        public Department Retrieve(string departmentName)
        {
            Department department;
            using (HoneyBadgerDB)
            {
                department = HoneyBadgerDB.Departments.FirstOrDefault(d => d.DepartmentName == departmentName);
            }
            return department;
        }
        public Department Retrieve(int departmentID)
        {
            Department department;
            using (HoneyBadgerDB)
            {
                department = HoneyBadgerDB.Departments.FirstOrDefault(d => d.DepartmentId == departmentID);
            }
            return department;
        }
        public void AddDepartment(Department department)
        {
            using (HoneyBadgerDB)
            {
                HoneyBadgerDB.Departments.Add(department);
                HoneyBadgerDB.SaveChanges();
            }
        }
    }
}
