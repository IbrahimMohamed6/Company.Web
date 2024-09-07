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
        [MinLength(2,ErrorMessage ="Minimum Name Is 2")]
        [MaxLength(50,ErrorMessage ="Maximum Name Is 100")]
        public string Name { get; set; }
        [Range(18,60)]
        public int Age { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone,MaxLength(20)]
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public Department? Department { get; set; }
        [ForeignKey("DepartmentID")]
        public int? DepartmentID { get; set; }
    }
}
