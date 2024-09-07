using Company.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatry.Interfaces
{
    public interface IEmployeeReposatry:IgenericReposatry<Employee>
    {
      
        IEnumerable<Employee> GetEmployeeByName(string Name);
        IEnumerable<Employee> GetEmployeesByAddress(string Adress);
       Employee GetEmployeesById(int id);
    }
}
