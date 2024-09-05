using Company.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services
{
    public interface IDepartmentServices
    {
        public Department GetById(int? id);
        public IEnumerable<Department> GetAll();
        public void Add(Department department);
        public void Update(Department department);
        public void Delete(Department department);
    }
}
