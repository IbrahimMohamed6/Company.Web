﻿using Company.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Confugrations
{
    internal class EmployeeConfugration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder.Property(X => X.Name).IsRequired(true).HasMaxLength(50);
            builder.HasIndex(X=>X.Email).IsUnique();
        }
    }
}
