using Company.Data.Contexts;
using Company.Data.Entites;
using Company.Reposatry.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatry.Reposatries
{
    public class EmployeeReposatry :GenericReposatry<Employee>, IEmployeeReposatry
    {
        private readonly CompanyDbContext _context;

        public EmployeeReposatry(CompanyDbContext context):base(context)
        {
            _context = context;
        }

        public Employee GetEmployeeByName(string Name)
        =>_context.Employees.Find(Name);

        public IEnumerable<Employee> GetEmployeesByAddress(string Adress)
        =>_context.Employees.Where(e => e.Address == Adress);
    }
}
