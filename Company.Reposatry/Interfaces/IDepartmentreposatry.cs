using Company.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatry.Interfaces
{
    public interface IDepartmentreposatry:IgenericReposatry<Department>
    {
        Department GetDepartmentByName(string Name);
        
    }
}
