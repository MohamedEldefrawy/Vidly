using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;

namespace Vidly.DAL.Configs
{
    public class MoviesConfigurations : EntityTypeConfiguration<Movie>
    {
        public MoviesConfigurations()
        {
            Property(m => m.NumberInStock)
                .IsRequired();
            Property(m => m.ReleaseDate)
                .HasColumnType("Date")
                .IsRequired();
            Property(m => m.DateAdded)
                .IsRequired()
                .HasColumnType("date");
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(25);
        }
    }
}