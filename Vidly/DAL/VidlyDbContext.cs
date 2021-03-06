﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Vidly.BL.Domain;
using Vidly.DAL.Configs;
using Vidly.Models;

namespace Vidly.DAL
{
    public class VidlyDbContext : IdentityDbContext<ApplicationUser>
    {
        public VidlyDbContext()
            : base("VidlyDBContext")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<MemberShipType> MemberShipTypes { get; set; }

        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalDetails> RentalDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CustomerConfigurations());
            modelBuilder.Configurations.Add(new MoviesConfigurations());
            modelBuilder.Configurations.Add(new RentalConfigurations());
            modelBuilder.Configurations.Add(new RentalDetailsConfigurations());
        }

        public static VidlyDbContext Create()
        {
            return new VidlyDbContext();
        }

    }
}