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
    }
}
