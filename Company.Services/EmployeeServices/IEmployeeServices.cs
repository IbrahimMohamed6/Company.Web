
using Company.Data.Entites;
using Company.Services.EmployeeServices.Dto;

namespace Company.Services
{
    public interface IEmployeeServices
    {
        public EmployeeDto GetById(int? id);
        public IEnumerable<EmployeeDto> GetAll();
        public void Add(EmployeeDto department);
        public void Update(EmployeeDto department);
        public void Delete(EmployeeDto department);
        public IEnumerable<EmployeeDto> GetEmployeeByName(string Name);
        
        
    }
}
