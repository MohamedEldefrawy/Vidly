using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;

namespace Vidly.DAL.Configs
{
    public class EmployeeConfigurations : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfigurations()
        {
            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Email)
                .IsOptional()
                .HasMaxLength(100);

            Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(15);

        }
    }
}