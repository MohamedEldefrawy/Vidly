using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;

namespace Vidly.DAL.Configs
{
    public class RentalConfigurations : EntityTypeConfiguration<Rental>
    {
        public RentalConfigurations()
        {
            HasRequired<ApplicationUser>(a => a.User)
                .WithMany(r => r.Rentals).HasForeignKey<string>(r => r.EmployeeID);
            Property(r => r.RentDate)
                .IsRequired()
                .HasColumnType("Date");
            Property(r => r.ReturnDate)
                .IsOptional()
                .HasColumnType("Date");
            Property(r => r.EmployeeID)
                .HasColumnType("nvarchar")
                .HasMaxLength(128);
        }
    }
}