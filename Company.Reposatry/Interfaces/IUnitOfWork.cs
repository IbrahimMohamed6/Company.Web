using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatry.Interfaces
{
    public interface IUnitOfWork
    {
        public IDepartmentreposatry Departmentreposatry { get; set; }
        public IEmployeeReposatry EmployeeReposatry { get; set; }

        int Complete();
    }
}
