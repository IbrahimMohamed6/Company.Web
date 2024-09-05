

using Company.Data.Entites;

namespace Company.Services
{
    public interface IEmployeeServices
    {
        public Employee GetById(int? id);
        public IEnumerable<Employee> GetAll();
        public void Add(Employee department);
        public void Update(Employee department);
        public void Delete(Employee department);
    }
}
