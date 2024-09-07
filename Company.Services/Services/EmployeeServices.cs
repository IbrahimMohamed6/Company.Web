
using Company.Data.Entites;
using Company.Reposatry.Interfaces;
using Company.Services.Employee.Dto;
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

        public EmployeeServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(EmployeeDto employeeDto)
        {
          

            Employee employee=new Employee();

            
       _unitOfWork.EmployeeReposatry.Add(employee);
            _unitOfWork.Complete();

        }

        public void Delete(EmployeeDto employee)
        {
            _unitOfWork.EmployeeReposatry.Delete(employee);
            _unitOfWork.Complete();
            
        }

        public IEnumerable<EmployeeDto> GetAll()
        { 
          var employees=  _unitOfWork.EmployeeReposatry.GetAll();
            return employees;

        }


        public EmployeeDto GetById(int? id)
        {
            if (id is null)
                throw new Exception("id Is Null");
            var GetEmployee = _unitOfWork.EmployeeReposatry.GetById(id.Value);
            if (GetEmployee is null)
                throw new Exception("Department is Null");
            return GetEmployee;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string Name)
          =>_unitOfWork.EmployeeReposatry.GetEmployeeByName(Name);

        public IEnumerable<EmployeeDto> GetEmployeesByAddress(string Adress)
       => _unitOfWork.EmployeeReposatry.GetEmployeesByAddress(Adress);
        public void Update(EmployeeDto employee)
        {
            _unitOfWork.EmployeeReposatry.Update(employee);
            _unitOfWork.Complete();
        }
    }
}
