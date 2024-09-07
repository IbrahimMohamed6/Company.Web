
using AutoMapper;
using Company.Data.Entites;
using Company.Reposatry.Interfaces;
using Company.Services.EmployeeServices.Dto;
using Company.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto employeeDto)
        {

            ///Manual Mapping
            ///Employee employee=new Employee()
            ///{
            ///    Address = employeeDto.Address,
            ///    Name = employeeDto.Name,
            ///    Age = employeeDto.Age,
            ///    Email = employeeDto.Email,
            ///    PhoneNumber = employeeDto.PhoneNumber,
            ///    CreatedAt = employeeDto.CreateAt,
            ///    Id= employeeDto.Id,
            ///    ImageUrl= employeeDto.ImageUrl,
            ///    DepartmentID= employeeDto.DepartmentID,
            ///};
            ///


            employeeDto.ImageUrl = DcumentSettings.UPLoadFile(employeeDto.Image, "Images");
            Employee employee =_mapper.Map<Employee>(employeeDto);
            
       _unitOfWork.EmployeeReposatry.Add(employee);
            _unitOfWork.Complete();

        }

        public void Delete(EmployeeDto employeeDto)
        {

            Employee employee =_mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeReposatry.Delete(employee);
            _unitOfWork.Complete();
           
        }

        public IEnumerable<EmployeeDto> GetAll()
        { 
          var employees=  _unitOfWork.EmployeeReposatry.GetAll();

            ///var MappedEmployees = employees.Select(X => new EmployeeDto
            ///{
            ///    DepartmentID=X.DepartmentID,
            ///    Address=X.Address,
            ///    Name=X.Name,
            ///    Age=X.Age,
            ///    Email=X.Email,
            ///    PhoneNumber=X.PhoneNumber,
            ///    ImageUrl=X.ImageUrl,
            ///    Id=X.Id,
            ///    CreateAt=X.CreatedAt
            ///});
            ///


            IEnumerable<EmployeeDto> MappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return MappedEmployees;
             
        }


        public EmployeeDto GetById(int? id)
        {
            if (id is null)
                throw new Exception("id Is Null");
            var GetEmployee = _unitOfWork.EmployeeReposatry.GetById(id.Value);
            if (GetEmployee is null)
                throw new Exception("Department is Null");
            ///EmployeeDto employeeDto = new EmployeeDto()
            ///{
            ///    Address = GetEmployee.Address,
            ///    Name = GetEmployee.Name,
            ///    Age = GetEmployee.Age,
            ///    Email = GetEmployee.Email,
            ///    PhoneNumber = GetEmployee.PhoneNumber,
            ///    CreateAt = GetEmployee.CreatedAt,
            ///    Id=GetEmployee.Id,
            ///    ImageUrl= GetEmployee.ImageUrl,
            ///    DepartmentID=GetEmployee.DepartmentID,
            ///};
            ///
            EmployeeDto employee = _mapper.Map<EmployeeDto>(GetEmployee);

            return employee;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string Name)
        {
          var employees=_unitOfWork.EmployeeReposatry.GetEmployeeByName(Name);

            IEnumerable<EmployeeDto> MappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return MappedEmployees;

        }
        public void Update(EmployeeDto employee)
        {
            //_unitOfWork.EmployeeReposatry.Update(employee);
            //_unitOfWork.Complete();
        }
    }
}
