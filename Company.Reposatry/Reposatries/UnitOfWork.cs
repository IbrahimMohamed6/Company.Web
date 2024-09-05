using Company.Data.Contexts;
using Company.Reposatry.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatry.Reposatries
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext _context;

        public UnitOfWork(CompanyDbContext context)
        {
            _context = context;
            Departmentreposatry = new DepartmentReposatry(context);
            EmployeeReposatry = new EmployeeReposatry(context);
        }
        public IDepartmentreposatry Departmentreposatry { get; set; }
        public IEmployeeReposatry EmployeeReposatry { get; set; }

        public int Complete()
        =>_context.SaveChanges();
    }
}
