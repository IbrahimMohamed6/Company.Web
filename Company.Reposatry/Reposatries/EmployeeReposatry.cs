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

        public EmployeeReposatry(CompanyDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee>GetEmployeeByName(string Name)
        =>_context.Employees.Where(E=>E.Name.Trim().ToLower().Contains(Name.Trim().ToLower()));

        public IEnumerable<Employee> GetEmployeesByAddress(string Adress)
        =>_context.Employees.Where(e => e.Address.Trim().ToLower() == Adress.Trim().ToLower());

        public Employee GetEmployeesById(int id)
         => _context.Employees.FirstOrDefault(e => e.Id == id);
    }
}
