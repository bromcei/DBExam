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

        public List<Department> Retrieve()
        {       
            using (HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext())
            {
                return HoneyBadgerDB.Departments.ToList();
            }
        }

        public Department Retrieve(string departmentName)
        {
            Department department;
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                department = HoneyBadgerDB.Departments.FirstOrDefault(d => d.DepartmentName == departmentName);
            }
            return department;
        }
        public Department Retrieve(int departmentID)
        {
            Department department;
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                department = HoneyBadgerDB.Departments.FirstOrDefault(d => d.DepartmentId == departmentID);
            }
            return department;
        }
        public void AddDepartment(Department department)
        {
            HoneyBadgerDbContext HoneyBadgerDB = new HoneyBadgerDbContext();
            using (HoneyBadgerDB)
            {
                HoneyBadgerDB.Departments.Add(department);
                HoneyBadgerDB.SaveChanges();
            }
        }
    }
}
