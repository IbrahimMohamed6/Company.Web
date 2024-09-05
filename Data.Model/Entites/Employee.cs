using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Entites
{
    public class Employee:BaseEntity
    {
        
        public string Name { get; set; }
        [Range(18,60)]
        public int Age { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone,MaxLength(20)]
        public string PhoneNumber { get; set; }
        public string? ImageUrl { get; set; }
        public Department? Department { get; set; }
        [ForeignKey("DepartmentID")]
        public int? DepartmentID { get; set; }
    }
}
