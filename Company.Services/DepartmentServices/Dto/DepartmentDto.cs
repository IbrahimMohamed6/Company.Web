using Company.Data.Entites;
using Company.Services.EmployeeServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.DepartmentServices.Dto
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int code { get; set; }
        public DateTime CreateAt { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; } = new HashSet<EmployeeDto>();
    }
}
