﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;

namespace Vidly.DAL.Configs
{
    public class CustomerConfigurations : EntityTypeConfiguration<Customer>
    {
        public CustomerConfigurations()
        {
            HasRequired(c => c.MemberShipType)
                .WithMany()
                .HasForeignKey(c => c.MemmberShipTypeID);

            Property(c => c.BirthDate)
                .IsOptional()
                .HasColumnType("Date");

            Property(c => c.MemmberShipTypeID).HasColumnName("MemberShipID");

        }
    }
}