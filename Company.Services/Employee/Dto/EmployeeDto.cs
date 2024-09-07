using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Services.Department.Dto;

namespace Company.Services.Employee.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [MinLength(2, ErrorMessage = "Minimum Name Is 2")]
        [MaxLength(50, ErrorMessage = "Maximum Name Is 100")]
        public string Name { get; set; }
        [Range(18, 60)]
        public int Age { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone, MaxLength(20)]
        public string PhoneNumber { get; set; }
        public string? ImageUrl { get; set; }
        public DepartmentDto Department { get; set; }
        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
