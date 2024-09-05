using Company.Data.Entites;
using Company.Reposatry.Interfaces;
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
        public void Add(Employee employee)
        {
           
            var MappedEmployee = new Employee
            {


                Address = employee.Address,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                PhoneNumber= employee.PhoneNumber,
                CreatedAt = DateTime.Now,
            };
       _unitOfWork.EmployeeReposatry.Add(MappedEmployee);
            _unitOfWork.Complete();

        }

        public void Delete(Employee employee)
        {
            _unitOfWork.EmployeeReposatry.Delete(employee);
            _unitOfWork.Complete();
            
        }

        public IEnumerable<Employee> GetAll()
        { 
          var employees=  _unitOfWork.EmployeeReposatry.GetAll();
            return employees;

        }


        public Employee GetById(int? id)
        {
            if (id is null)
                throw new Exception("id Is Null");
            var GetEmployee = _unitOfWork.EmployeeReposatry.GetById(id.Value);
            if (GetEmployee is null)
                throw new Exception("Department is Null");
            return GetEmployee;
        }

        public void Update(Employee employee)
        {
            _unitOfWork.EmployeeReposatry.Update(employee);
            _unitOfWork.Complete();
        }
    }
}
