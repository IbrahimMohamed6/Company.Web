using AutoMapper;
using Company.Data.Entites;
using Company.Reposatry.Interfaces;
using Company.Services.DepartmentServices.Dto;
using Company.Services.EmployeeServices.Dto;
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
        private readonly IMapper _mapper;

        public DepartmentServices(IUnitOfWork unitOfWork ,IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(DepartmentDto departmentDto)
        {
            

            var MappedDepartmentDto = _mapper.Map<Department>(departmentDto);
            _unitOfWork.Departmentreposatry.Add( MappedDepartmentDto);
            _unitOfWork.Complete();
            
        }

        public void Delete(DepartmentDto departmentDto)
        {
            var MappedDepartmentDto = _mapper.Map<Department>(departmentDto);

            _unitOfWork.Departmentreposatry.Delete(MappedDepartmentDto);
            _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var Department = _unitOfWork.Departmentreposatry.GetAll();

            var mappedDepartments=_mapper.Map<IEnumerable<DepartmentDto>>(Department);
            return mappedDepartments;
        }

        public DepartmentDto GetById(int? id)
        {
            if(id is null)
                throw new Exception("id Is Null");
            var GetDepartment=_unitOfWork.Departmentreposatry.GetById(id.Value);
            if (GetDepartment is null)
                throw new Exception("Department is Null");
            var MappedDepartmentDto = _mapper.Map<DepartmentDto>(GetDepartment);
            return MappedDepartmentDto;
        }

        public void Update(DepartmentDto department)
        {
            //_unitOfWork.Departmentreposatry.Update(department);
            //_unitOfWork.Complete();
        }
    }
}
