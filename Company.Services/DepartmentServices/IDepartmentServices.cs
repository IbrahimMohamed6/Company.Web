using Company.Data.Entites;
using Company.Services.DepartmentServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services
{
    public interface IDepartmentServices
    {
        public DepartmentDto GetById(int? id);
        public IEnumerable<DepartmentDto> GetAll();
        public void Add(DepartmentDto department);
        public void Update(DepartmentDto department);
        public void Delete(DepartmentDto department);
    }
}
