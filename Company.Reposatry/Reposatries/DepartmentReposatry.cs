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
    public class DepartmentReposatry : GenericReposatry<Department>, IDepartmentreposatry
    {
        private readonly CompanyDbContext _context;

        public DepartmentReposatry(CompanyDbContext context) : base(context)
        {
            _context = context;
        }

        public Department GetDepartmentByName(string Name)
        => _context.Departments.Find(Name);
    }
}
