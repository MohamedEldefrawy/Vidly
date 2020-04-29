using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;

namespace Vidly.DAL.Configs
{
    public class RentalDetailsConfigurations : EntityTypeConfiguration<RentalDetails>
    {
        public RentalDetailsConfigurations()
        {
            Property(r => r.Quantity)
                .IsRequired();
            Property(r => r.UnitPrice)
                .IsRequired()
                .HasColumnType("Decimal").HasPrecision(9,2);
        }
    }
}