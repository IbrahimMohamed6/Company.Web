using Company.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Confugrations
{
    internal class DepartmentConfuration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(P=>P.Id).UseIdentityColumn(10,10);
            builder.HasIndex(X=>X.Name).IsUnique();
        }
    }
}
