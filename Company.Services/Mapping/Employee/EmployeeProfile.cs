using AutoMapper;
using Company.Data.Entites;
using Company.Services.DepartmentServices.Dto;
using Company.Services.EmployeeServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Mapping
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee,EmployeeDto>().ReverseMap();
            CreateMap<Department,DepartmentDto>().ReverseMap();
            
        }
    }
}
