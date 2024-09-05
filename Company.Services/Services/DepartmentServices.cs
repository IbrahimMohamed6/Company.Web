using Company.Data.Entites;
using Company.Reposatry.Interfaces;
using Company.Reposatry.Reposatries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentServices(IUnitOfWork   unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Department department)
        {
            var MappedDepartment = new Department
            {
                code = department.code,
                Name = department.Name,
                CreatedAt = DateTime.Now,
            };
            _unitOfWork.Departmentreposatry.Add( MappedDepartment );
            _unitOfWork.Complete();
            
        }

        public void Delete(Department department)
        {
            _unitOfWork.Departmentreposatry.Delete(department);
            _unitOfWork.Complete();
        }

        public IEnumerable<Department> GetAll()
        {
            var Department = _unitOfWork.Departmentreposatry.GetAll();
            return Department;
        }

        public Department GetById(int? id)
        {
            if(id is null)
                throw new Exception("id Is Null");
            var GetDepartment=_unitOfWork.Departmentreposatry.GetById(id.Value);
            if (GetDepartment is null)
                throw new Exception("Department is Null");
            return GetDepartment;
        }

        public void Update(Department department)
        {
            _unitOfWork.Departmentreposatry.Update(department);
            _unitOfWork.Complete();
        }
    }
}
