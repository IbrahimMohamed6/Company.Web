using Company.Data.Entites;
using Company.Reposatry.Interfaces;
using Company.Reposatry.Reposatries;
using Company.Services.Department.Dto;
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
        public void Add(DepartmentDto department)
        {
            Department department1 =new Department();
            var MappedDepartmentDto = new DepartmentDto
            {
                code = department.code,
                Name = department.Name,
                CreateAt = DateTime.Now,
            };
            _unitOfWork.Departmentreposatry.Add( MappedDepartmentDto);
            _unitOfWork.Complete();
            
        }

        public void Delete(DepartmentDto department)
        {
            _unitOfWork.Departmentreposatry.Delete(department);
            _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var Department = _unitOfWork.Departmentreposatry.GetAll();
            return Department;
        }

        public DepartmentDto GetById(int? id)
        {
            if(id is null)
                throw new Exception("id Is Null");
            var GetDepartment=_unitOfWork.Departmentreposatry.GetById(id.Value);
            if (GetDepartment is null)
                throw new Exception("Department is Null");
            return GetDepartment;
        }

        public void Update(DepartmentDto department)
        {
            _unitOfWork.Departmentreposatry.Update(department);
            _unitOfWork.Complete();
        }
    }
}
